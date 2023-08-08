Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FRmTraficUpdatePrecio
    Private Sub FRmTraficUpdatePrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            btnEsquema.FlatStyle = FlatStyle.Flat
            btnEsquema.FlatAppearance.BorderSize = 0
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        '6 PRECIO
        '10 CVE_ESQIMPU  
        '11 DESCRIPESQ
        'Var2 = Fg(Fg.Row, 6)
        'Var3 = Fg(Fg.Row, 10)
        'Var4 = Fg(Fg.Row, 11)

        TPRECIO.Value = Var2
        tCVE_ESQIMPU.Text = Var3
        LtEsquema.Text = Var4

    End Sub

    Private Sub FRmTraficUpdatePrecio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Try
            TPRECIO.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        Try
            SQL = "UPDATE PRECIO_X_PROD" & Empresa & " SET  PRECIO = " & TPRECIO.Value & " WHERE CVE_ART = '" & LtArt.Text & "' AND CVE_PRECIO = 1"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        Me.Close()
                    End If
                End If
            End Using

            SQL = "UPDATE INVE" & Empresa & " SET CVE_ESQIMPU = " & tCVE_ESQIMPU.Text & " WHERE CVE_ART = '" & LtArt.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        Me.Close()
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEsquema_Click(sender As Object, e As EventArgs) Handles btnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ESQIMPU.Text = Var4
                LtEsquema.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_ESQIMPU_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ESQIMPU.KeyDown

    End Sub

    Private Sub tCVE_ESQIMPU_Validated(sender As Object, e As EventArgs) Handles tCVE_ESQIMPU.Validated
        Try
            If tCVE_ESQIMPU.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Esquema", tCVE_ESQIMPU.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Esquema inexistente")
                Else
                    LtEsquema.Text = CADENA
                End If
            End If
        Catch ex As Exception
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
