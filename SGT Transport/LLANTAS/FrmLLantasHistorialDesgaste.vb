Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmLLantasHistorialDesgaste
    Private TIPO_LLANTAS As Integer = 0
    Private Sub FrmLLantasHistorialDesgaste_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        Catch ex As Exception
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TIPO_LLANTAS,0) AS TIP_LLANT FROM GCPARAMGENERALES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TIPO_LLANTAS = dr("TIP_LLANT")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        DESPLEGAR()

    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Rows.Count = 1
            If TIPO_LLANTAS = 0 Then
                SQL = "SELECT PROFUNDIDAD AS PROF, FECHAELAB AS FECH FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = '" & Var10 & "' ORDER BY FECHAELAB"
            Else
                SQL = "SELECT PROFUNDIDAD_ACTUAL AS PROF, FECHA AS FECH FROM GCINSPEC_LLANTAS WHERE NUM_ECONOMICO = '" & Var11 & "' ORDER BY FECHAELAB"
            End If
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("PROF") & vbTab & dr("FECH"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmLLantasHistorialDesgaste_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click

    End Sub
End Class
