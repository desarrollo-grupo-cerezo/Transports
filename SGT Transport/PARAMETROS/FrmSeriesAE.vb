Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmSeriesAE
    Private TIP_DOC As String

    Private Sub frmSeriesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Me.KeyPreview = True
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        TIP_DOC = Var5
        TTIP_DOC.Text = ""
        TFOLIODESDE.Text = ""
        TFOLIOHASTA.Text = ""
        TSERIE.Text = ""
        TULT_DOC.Text = ""

        If Var1 = "Nuevo" Then
            Try
                TSERIE.Enabled = True
                TTIP_DOC.Text = TIP_DOC
                TSERIE.Text = Var6
                TSERIE.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT L.TIP_DOC, L.FOLIODESDE, L.FOLIOHASTA, L.SERIE, L.ULT_DOC, L.FECH_ULT_DOC, L.STATUS
                    FROM FOLIOSC" & Empresa & " L 
                    WHERE LOWER(TIP_DOC) = '" & TIP_DOC.ToLower & "' AND SERIE = '" & Var6 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TTIP_DOC.Text = dr("TIP_DOC").ToString.ToLower
                    TFOLIODESDE.Text = dr("FOLIODESDE").ToString
                    TFOLIOHASTA.Text = dr("FOLIOHASTA").ToString
                    TSERIE.Text = dr("SERIE").ToString
                    TULT_DOC.Text = dr("ULT_DOC").ToString
                End If
                dr.Close()

                TTIP_DOC.Enabled = False
                TSERIE.Enabled = False
                TSERIE.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        SQL = "UPDATE FOLIOSC" & Empresa & " SET FOLIODESDE = @FOLIODESDE, FOLIOHASTA = @FOLIOHASTA, ULT_DOC = @ULT_DOC
            WHERE LOWER(TIP_DOC) = @TIP_DOC AND SERIE = @SERIE
            IF @@ROWCOUNT = 0
            INSERT INTO FOLIOSC" & Empresa & " (TIP_DOC, FOLIODESDE, FOLIOHASTA, SERIE, ULT_DOC, FECH_ULT_DOC, STATUS)
            VALUES(@TIP_DOC, @FOLIODESDE, @FOLIOHASTA, @SERIE, @ULT_DOC, GETDATE(), 'D')"

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = TIP_DOC.ToLower
            cmd.Parameters.Add("@FOLIODESDE", SqlDbType.Int).Value = CONVERTIR_TO_INT(TFOLIODESDE.Text)
            cmd.Parameters.Add("@FOLIOHASTA", SqlDbType.Int).Value = CONVERTIR_TO_INT(TFOLIOHASTA.Text)
            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = TSERIE.Text
            cmd.Parameters.Add("@ULT_DOC", SqlDbType.Int).Value = CONVERTIR_TO_INT(TULT_DOC.Text)
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    Try
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT * FROM FOLIOSC" & Empresa & " WHERE LOWER(TIP_DOC) = '" & TIP_DOC.ToLower & "' AND SERIE = 'STAND.'"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If Not dr2.HasRows Then
                                    SQL = "INSERT INTO FOLIOSC" & Empresa & " (TIP_DOC, FOLIODESDE, FOLIOHASTA, 
                                        SERIE, ULT_DOC, FECH_ULT_DOC) VALUES ('G', 0, 0, 'STAND.', 0, 
                                        CONVERT(varchar, GETDATE(), 112))"
                                    Dim DatoReulst As Boolean = EXECUTE_QUERY_NET(SQL)
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

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
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub frmSeriesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub frmSeriesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
End Class
