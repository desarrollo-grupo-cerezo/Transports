Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmTipoActivosAE
    Private Sub FrmTipoActivosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
            Me.KeyPreview = True
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                TCLAVE.Text = GET_MAX("GCTIPACTIV", "CLAVE")
                TCLAVE.Enabled = False
                TDESCR.Text = ""
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.DESCRIP, P.DEDNORMAL, P.DEDIMED, P.MAXDED, P.METODODEP, P.DEPPROY, P.CTAAACTV, 
                    P.CTADEPRE, P.CTAGASTOS, P.CTAPERGAN
                    FROM GCTIPACTIV P WHERE CLAVE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCLAVE.Text = Var2
                    TDESCR.Text = dr("DESCRIP")
                    TDEDNORMAL.Text = dr("DEDNORMAL")
                    TDEDIMED.Text = dr("DEDIMED")
                    TMAXDED.Text = dr("MAXDED")
                    Select Case dr("METODODEP")
                        Case "L"
                            RadLineaReacta.Checked = True
                        Case "D"
                            RadDobleSaldo.Checked = True
                        Case "S"
                            RadSuma.Checked = True
                    End Select

                    TDEPPROY.Text = dr("DEPPROY")
                    TCTAAACTV.Text = dr("CTAAACTV")
                    TCTADEPRE.Text = dr("CTADEPRE")
                    TCTAGASTOS.Text = dr("CTAGASTOS")
                    TCTAPERGAN.Text = dr("CTAPERGAN")
                Else
                    TCLAVE.Text = 0
                    TDESCR.Text = ""
                    TDEDNORMAL.Value = 0
                    TDEDIMED.Value = 0
                    TMAXDED.Value = 0
                    'tMETODODEP.text = ""
                    TDEPPROY.Text = 0
                    TCTAAACTV.Text = ""
                    TCTADEPRE.Text = ""
                    TCTAGASTOS.Text = ""
                    TCTAPERGAN.Text = ""
                End If
                dr.Close()

                TCLAVE.Enabled = False
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmTipoActivosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub FrmTipoActivosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarGrabar.Click
        Dim METODODEP As String

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        If RadLineaReacta.Checked Then
            METODODEP = "L"
        ElseIf RadDobleSaldo.Checked Then
            METODODEP = "D"
        ElseIf Radsuma.Checked Then
            METODODEP = "S"
        Else
            METODODEP = ""
        End If

        SQL = "IF EXISTS (SELECT CLAVE FROM GCTIPACTIV WHERE CLAVE = @CLAVE)
                    UPDATE GCTIPACTIV SET DESCRIP = @DESCRIP, DEDNORMAL = @DEDNORMAL, DEDIMED = @DEDIMED, MAXDED = @MAXDED, METODODEP = @METODODEP,
                    DEPPROY = @DEPPROY, CTAAACTV = @CTAAACTV, CTADEPRE = @CTADEPRE, CTAGASTOS = @CTAGASTOS, CTAPERGAN = @CTAPERGAN
                    WHERE CLAVE = @CLAVE
                ELSE
                    INSERT INTO GCTIPACTIV (CLAVE, DESCRIP, DEDNORMAL, DEDIMED, MAXDED, METODODEP, DEPPROY, CTAAACTV, CTADEPRE, CTAGASTOS, 
                    CTAPERGAN) VALUES (@CLAVE, @DESCRIP, @DEDNORMAL, @DEDIMED, @MAXDED, @METODODEP, @DEPPROY, @CTAAACTV, @CTADEPRE, 
                    @CTAGASTOS, @CTAPERGAN)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CLAVE", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCLAVE.Text)
                cmd.Parameters.Add("@DESCRIP", SqlDbType.VarChar).Value = TDESCR.Text
                cmd.Parameters.Add("@DEDNORMAL", SqlDbType.Float).Value = TDEDNORMAL.Value
                cmd.Parameters.Add("@DEDIMED", SqlDbType.Float).Value = TDEDIMED.Value
                cmd.Parameters.Add("@MAXDED", SqlDbType.Float).Value = TMAXDED.Value
                cmd.Parameters.Add("@METODODEP", SqlDbType.VarChar).Value = METODODEP
                cmd.Parameters.Add("@DEPPROY", SqlDbType.Float).Value = TDEPPROY.Value
                cmd.Parameters.Add("@CTAAACTV", SqlDbType.VarChar).Value = TCTAAACTV.Text
                cmd.Parameters.Add("@CTADEPRE", SqlDbType.VarChar).Value = TCTADEPRE.Text
                cmd.Parameters.Add("@CTAGASTOS", SqlDbType.VarChar).Value = TCTAGASTOS.Text
                cmd.Parameters.Add("@CTAPERGAN", SqlDbType.VarChar).Value = TCTAPERGAN.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
            MsgBox("El tipo activo se grabo correctamente")

            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class