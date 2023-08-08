Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmSeriesCompras
    Private Sub frmSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()

        Catch ex As Exception
        End Try
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                  "FROM FOLIOSC" & Empresa & " WHERE LOWER(TIP_DOC) = '" & TIPO_COMPRA.ToLower & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("LETRA") & vbTab & dr("ULTDOC"))
            Loop
            dr.Close()
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        btnAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            LETRA_COMPRA = Fg(Fg.Row, 1)
            FOLIO_COMPRA = Fg(Fg.Row, 2) + 1


            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSeriesCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
