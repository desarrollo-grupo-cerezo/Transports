Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmConcepFlujoAE
    Private Sub FrmFlujoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            Me.CenterToScreen()
            If Var11 = "E" Then
                Me.Text = "Concepto entrada flujo de efectivo"
            Else
                Me.Text = "Concepto salida flujo de efectivo"
            End If
        Catch ex As Exception
        End Try

        Me.KeyPreview = True
        If Var1 = "Nuevo" Then
            Try
                Dim CLAVE As Integer

                CLAVE = GET_MAX("SOENTRADADINERO", "CLAVE", 0, " WHERE TIPO = '" & Var11 & "'")
                TCLAVE.Text = CLAVE

                If Var11 = "S" Then
                    If CLAVE <= 49 Then
                        TCLAVE.Text = Convert.ToInt32(TCLAVE.Text) + 49
                    End If
                End If

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

                If Not IsNumeric(Var2) Then Var2 = "0"

                SQL = "SELECT E.CLAVE, E.DESCR, E.TIPO 
                    FROM SOENTRADADINERO E 
                    WHERE CLAVE = " & Var2 & " AND TIPO = '" & Var11 & "'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCLAVE.Text = dr("CLAVE").ToString
                    TDESCR.Text = dr("DESCR").ToString
                Else
                    TCLAVE.Text = ""
                    TDESCR.Text = ""
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
    Private Sub FrmFlujoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarGrabar.Click

        SQL = "IF EXISTS (SELECT TIPO FROM SOENTRADADINERO WHERE CLAVE = @CLAVE AND TIPO = @TIPO)
            UPDATE SOENTRADADINERO SET DESCR = @DESCR
            WHERE CLAVE = @CLAVE AND TIPO = @TIPO
        ELSE
            INSERT INTO SOENTRADADINERO (CLAVE, DESCR, TIPO) VALUES (@CLAVE, @DESCR, @TIPO)"

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CLAVE", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCLAVE.Text)
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
                cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = Var11

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El flujo se grabo correctamente")
                        Me.Close()
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class