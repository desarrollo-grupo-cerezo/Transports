Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Public Class FrmSelCuentaBancaria
    Private Sub FrmSelCuentaBancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()

        Catch ex As Exception
        End Try

        Try
            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("NUM.", GetType(System.String))
            dt.Columns.Add("CUENTA", GetType(System.String))
            dt.Columns.Add("BANCO", GetType(System.String))

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT TRY_PARSE(ISNULL(CLAVE,'0') AS INT) AS CVE, CUENTA_BANCARIA, ISNULL(NOMBRE_BANCO,'') AS NOMBRE
                    FROM CUENTA_BENEF" & Empresa & " 
                    WHERE ISNULL(STATUS,'A') = 'A' 
                    ORDER BY TRY_PARSE(CLAVE AS INT)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CVE"), dr("CUENTA_BANCARIA"), dr("NOMBRE"))
                    End While
                End Using
            End Using

            CboCuentabancaria.TextDetached = True
            CboCuentabancaria.ItemsDataSource = dt.DefaultView
            CboCuentabancaria.ItemsDisplayMember = "CUENTA"
            CboCuentabancaria.ItemsValueMember = "NUM."
            CboCuentabancaria.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboCuentabancaria.HtmlPattern = "<table><tr><td width=30>{NUM.}</td><td width=150>{CUENTA}</td><td width=170>{BANCO}</td><td width=220></tr></table>"

        Catch ex As Exception
            Bitacora("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmSelCuentaBancaria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click

        If CboCuentabancaria.SelectedIndex = -1 Then
            MsgBox("Por favor selecciones una cuenta bancaria")
            Return
        End If

        Var8 = Format(CInt(CboCuentabancaria.Items(CboCuentabancaria.SelectedIndex)), "00")
        Var9 = CboCuentabancaria.Text

        Me.Close()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub CboCuentabancaria_KeyDown(sender As Object, e As KeyEventArgs) Handles CboCuentabancaria.KeyDown
        If e.KeyCode = 13 Then
            BarAceptar_Click(Nothing, Nothing)
        End If
    End Sub
End Class
