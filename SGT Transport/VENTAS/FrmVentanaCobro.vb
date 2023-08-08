Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmVentanaCobro
    Private Sub FrmVentasTotales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            If Var7 = "TOTALES" Then
                BtnGrabar.Visible = False
                Fg.Visible = False
                FgP.Visible = False
                Panel1.Left = Panel1.Left - (Fg.Width / 2)
                TIMPORTE_RECIBIDO.Visible = False
                Lt1.Visible = False
                Lt2.Visible = False
                LtCambio.Visible = False
            End If
            Fg.Rows.Count = 1
            FgP.Rows.Count = 1

        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CONC" & Empresa & " WHERE TIPO = 'A' AND CON_REFER = 'S' ORDER BY NUM_CPTO"
                cmd.CommandText = SQL

                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("NUM_CPTO") & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using

            TIMPORTE_RECIBIDO.Value = 0
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Try
            Dim i As Integer = 0
            VarFORM = "GRABAR"
            For k = 1 To aTPV.GetLength(0)
                aTPV(i, 0) = ""
                aTPV(i, 1) = ""
            Next
            For k = 1 To FgP.Rows.Count - 1
                aTPV(i, 0) = FgP(k, 1)
                aTPV(i, 1) = FgP(k, 3)
                i += 1
            Next
            Me.Close()
        Catch ex As Exception
            Bitacora("32. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("32. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Var8 = ""
        VarFORM = ""
        Me.Close()
    End Sub


    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Dim PAGOS As Decimal, Abono As Decimal = 0
        Dim IMPORTE As Decimal = 0
        Try
            Dim r_ As Integer

            r_ = Fg.Row
            VarFORM2 = ""
            PAGOS = PAGOS_REALIZADOS()
            Try
                Var21 = Fg(r_, 1)
                IMPORTE = LtTotal.Text.Replace(",", "")
            Catch ex As Exception
            End Try
            If IsNumeric(LtTotal.Text.Replace(",", "")) Then
                Var22 = Math.Round(LtTotal.Text.Replace(",", "") - PAGOS, 4)
            Else
                Var22 = 0
            End If
            If Var22 = 0 Then
                MsgBox("El documento se pago en su totalidad")
                BtnGrabar.Focus()
                Return
            End If
            Fg.Row = r_
            FrmVentanaMonto.ShowDialog()
            If VarFORM2.Trim.Length > 0 Then

                If Fg(r_, 1) = "10" Then
                    Try
                        If IsNumeric(VarFORM2) Then
                            If CDec(VarFORM2) + PAGOS > IMPORTE Then
                                Abono = IMPORTE - PAGOS
                                PAGOS += CDec(VarFORM2)
                            Else
                                Abono = CDec(VarFORM2)
                                PAGOS += CDec(VarFORM2)
                            End If

                        End If
                    Catch ex As Exception
                        Bitacora("32. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    Try
                        If IsNumeric(VarFORM2) Then
                            If CDec(VarFORM2) + PAGOS > IMPORTE Then
                                MsgBox("Los pagos no pueden ser mayor al importe")
                                Return
                            End If
                        End If
                        Abono = CDec(VarFORM2)
                        PAGOS += Abono
                    Catch ex As Exception
                        Bitacora("33. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                FgP.AddItem("" & vbTab & Fg(r_, 1) & vbTab & Fg(r_, 2) & vbTab & Abono)

                TIMPORTE_RECIBIDO.Value = PAGOS
                If IMPORTE >= PAGOS Then
                    LtCambio.Text = "0"
                Else
                    LtCambio.Text = Format(CDec(LtTotal.Text.Replace(",", "")) - PAGOS, "###,###,##0.00")
                End If

                Var22 = Math.Round(LtTotal.Text.Replace(",", "") - PAGOS, 4)
                If Var22 <= 0.001 Then
                    BtnGrabar.Focus()
                End If
            End If
        Catch ex As Exception
            Bitacora("34. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("34. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function PAGOS_REALIZADOS() As Decimal
        Try
            Dim SUMA As Decimal = 0

            For k = 1 To FgP.Rows.Count - 1
                SUMA += FgP(k, 3)
            Next
            Return SUMA
        Catch ex As Exception
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Fg_DoubleClick(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgP_KeyDown(sender As Object, e As KeyEventArgs) Handles FgP.KeyDown
        Try
            If e.KeyCode = 38 Then
                If FgP.Row = 1 Then
                    Fg.Focus()
                End If
            End If

            If e.KeyCode = Keys.Delete Then
                FgP.RemoveItem(FgP.Row)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgP_MouseClick(sender As Object, e As MouseEventArgs) Handles FgP.MouseClick
        Try
            If FgP.Row > 0 Then
                If e.Button = MouseButtons.Right Then
                    Dim m As New ContextMenu()
                    m.MenuItems.Add(New MenuItem("Eliminar pago"))
                    m.MenuItems.Add(New MenuItem("Cancelar"))
                    m.Show(FgP, New Point(e.X, e.Y))
                    If FgP.Row > 0 Then

                        FgP.RemoveItem(FgP.Row)
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TIMPORTE_RECIBIDO_KeyDown(sender As Object, e As KeyEventArgs) Handles TIMPORTE_RECIBIDO.KeyDown
        Try
            If e.KeyCode = 13 Then
                BtnGrabar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmVentanaCobro_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmVentanaCobro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
