Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmEstatusUnidadesStOper
    Private Sub FrmEstatusUnidadesStOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Fg.Dock = DockStyle.Fill

        Catch ex As Exception
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ST_OPER, DESCR FROM GCSTATUS_OPER WHERE STATUS = 'A'"
                '                               GCCAT_STATUS_UNIDADES
                Fg.Rows.Count = 1
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_ST_OPER") & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If Not String.IsNullOrEmpty(Fg(Fg.Row, 1)) Then
                Var26 = Fg(Fg.Row, 1)
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

    Private Sub FrmEstatusUnidadesStOper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class