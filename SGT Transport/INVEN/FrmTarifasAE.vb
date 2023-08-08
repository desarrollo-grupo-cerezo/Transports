Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmTarifasAE
    Private Sub FrmTarifasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                TCVE_ART.Text = ""
                TCVE_ART.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Fg.Rows.Count = 1
                SQL = "SELECT E.CVE_PRECIO, I.DESCR
                    FROM GCTARIFAS T 
                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = T.CVE_ART
                    WHERE CVE_ART = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                Do While dr.Read
                    Fg.AddItem("" & vbTab & dr(""))
                Loop
                dr.Close()
                TCVE_ART.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmTarifasAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnInve_Click(sender As Object, e As EventArgs) Handles BtnInve.Click

    End Sub

    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown

    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated

    End Sub
End Class
