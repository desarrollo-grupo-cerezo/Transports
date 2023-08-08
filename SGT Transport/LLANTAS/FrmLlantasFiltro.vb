Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmLlantasFiltro
    Private Sub FrmLlantasFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        Try
            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_STATUS, DESCR FROM GCLLANTA_STATUS WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_STATUS AS INT)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_STATUS") & ";" & dr("DESCR"))
                    End While
                End Using
            End Using
            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmLlantasFiltro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarAceptar.Click
        Dim CADENA_ST As String = ""
        Try
            For row As Integer = 0 To C1List1.ListCount - 1
                Dim cellValue As Object = C1List1.GetDisplayText(row, 0)

                If C1List1.GetSelected(row) Then
                    CADENA_ST += cellValue.ToString & "','"

                End If
            Next

            If CADENA_ST.Trim.Length = 0 Then
                MsgBox("Por favor seleccione almenus un estatus")
                Return
            End If

            Var14 = "'" & CADENA_ST.Substring(0, CADENA_ST.Length - 2)
            Me.Close()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Var14 = ""
        Me.Close()
    End Sub
End Class