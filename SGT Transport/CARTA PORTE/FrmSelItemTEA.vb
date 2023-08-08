Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmSelItemTEA
    Private Sub FrmSelItemTEA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Me.CenterToScreen()
            'Fg.Cols(1).Width = 90
            'Fg.Cols(2).Width = 150
            'Fg.Cols(3).Width = 150
            'Fg.Cols(4).Width = 75
            'Fg.Cols(5).Width = 60
            'Fg.Cols(6).Width = 60
            SQL = "SELECT TOP 1000 MAX(succamion) AS folio_tea, ISNULL(MAX(pag),'') as timbrado, MAX(sucentrega) AS suce, MAX(sucsolicita) AS sucs, 
                MAX(f_entrega) as f_ent, MAX(f_recepcion) as f_rec, MAX(alm1) as num_alm, SUM(estatus) AS st
                FROM movs 
                WHERE isnull(cancelado,'N') = 'N' AND ISNULL(pag,'') <> 'S'
                GROUP BY serie, folio ORDER BY max(f_entrega) DESC"

            DESPLEGAR()

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR()
        Dim s As String

        Fg.Rows.Count = 1
        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor

        Try
            Using cmd As SqlCommand = cnSQL.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        s = dr("folio_tea") & vbTab '1
                        s &= dr("suce") & vbTab     '2
                        s &= dr("sucs") & vbTab     '3
                        s &= dr("f_ent") & vbTab    '4
                        s &= IIf(dr("st") > 0, "Enviado", "") & vbTab      '5
                        s &= dr("num_alm") & vbTab  '6
                        's &= dr("timbrado") & vbTab '2
                        Fg.AddItem("" & vbTab & s)
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Sub FrmSelItemTEA_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        BarAceptar_Click(Nothing, Nothing)
    End Sub
    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1)
                Var5 = Fg(Fg.Row, 2)
                Var6 = Fg(Fg.Row, 3)
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TBox.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TBox_TextChanged(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles TBox.TextChanged
        Try
            SQL = "SELECT TOP 1000 MAX(succamion) AS folio_tea, ISNULL(MAX(pag),'') as timbrado, MAX(sucentrega) AS suce, MAX(sucsolicita) AS sucs, 
                MAX(f_entrega) as f_ent, MAX(f_recepcion) as f_rec, MAX(alm1) as num_alm, SUM(estatus) AS st
                FROM movs 
                WHERE isnull(cancelado,'N') = 'N' AND ISNULL(pag,'') <> 'S' AND 
                (succamion LIKE '%'" & TBox.Text & "%' OR sucentrega LIKE '%'" & TBox.Text & "%' OR 
                sucsolicita LIKE '%'" & TBox.Text & "%')
                GROUP BY serie, folio ORDER BY max(f_entrega) DESC"
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class