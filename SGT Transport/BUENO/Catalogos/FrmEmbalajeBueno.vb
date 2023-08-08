Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmEmbalajeBueno
    Private Sub FrmEmbalajeBueno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try
            Me.WindowState = FormWindowState.Maximized
            Fg.Dock = DockStyle.Fill

            Fg.Rows.Count = 1
            Fg.Cols.Count = 3

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "CLAVE"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "DESCR"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)


            Fg.Cols(1).Width = 100
            Fg.Cols(2).Width = 600

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmEmbalajeBueno_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Embalaje")
        Me.Dispose()
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT CLAVE, DESCR, STATUS, FECHAELAB, UUID 
                FROM GCEMBALAJE WHERE STATUS = 'A'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("DESCR"))
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmEmbalajeBuenoAE.ShowDialog()
            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            FrmEmbalajeBuenoAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarRefrescar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarRefrescar.Click
        DESPLEGAR()
    End Sub

    Private Sub BarCancelar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarCancelar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCEMBALAJE SET STATUS = 'B' WHERE  CLAVE = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub


End Class