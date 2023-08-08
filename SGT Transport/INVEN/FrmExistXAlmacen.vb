Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmExistXAlmacen
    Private Sub FrmExistXAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try
            Me.CenterToScreen()

            Fg.Rows.Count = 1
            Lt1.Text = Var46 & " " & Var47

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT M.CVE_ALM, DESCR, M.EXIST
                    FROM MULT" & Empresa & " M
                    LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = M.CVE_ALM
                    WHERE CVE_ART = '" & Var46 & "' ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_ALM") & vbTab & dr("DESCR") & vbTab & dr("EXIST"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmExistXAlmacen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "EXISTENCIA")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
