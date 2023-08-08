Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmStatusViajeUnidad
    Private CVE_VIAJE As String
    Private TIPO_STATUS As String
    Private Sub FrmStatusViajeUnidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Me.CenterToScreen()

            BarMenu.BackColor = Color.FromArgb(207, 221, 238)

        Catch ex As Exception
        End Try

        CVE_VIAJE = Var9
        TIPO_STATUS = Var8
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE, DESCR FROM GCCAT_STATUS_UNIDADES"
                '                               GCCAT_STATUS_UNIDADES
                Fg.Rows.Count = 1
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        'If CVE_VIAJE.Trim.Length = 0 Then
                        'If dr("CLAVE") = "7" Or dr("CLAVE") = "8" Then
                        'Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("DESCR"))
                        'End If
                        'Else
                        Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("DESCR"))
                        'End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmStatusViajeUnidad_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If Not String.IsNullOrEmpty(Fg(Fg.Row, 1)) Then
                Dim CVE_ST_VIA As Integer = 0
                Dim CVE_ST_UNI As Integer = 0

                CVE_ST_UNI = Fg(Fg.Row, 1)

                Select Case CVE_ST_UNI
                    Case 1
                        CVE_ST_VIA = 1
                    Case 2
                        CVE_ST_VIA = 2
                    Case 3
                        CVE_ST_VIA = 2
                    Case 4
                        CVE_ST_VIA = 2
                    Case 5
                        CVE_ST_VIA = 3
                    Case 6
                        CVE_ST_VIA = 1
                    Case 7
                    Case 8
                    Case 9
                End Select
                'Var9 = Fg(Fg.Row, 3).ToString 'VIAJE
                'Var19 = Fg(Fg.Row, 1).ToString 'UNIDAD
                Var26 = CVE_ST_UNI
                Var27 = CVE_ST_VIA
                Me.Close()
            End If
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
