Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmEstacionTrab
    Private Sub FrmEstacionTrab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Fg.Dock = DockStyle.Fill

            Fg.Cols(1).StarWidth = "*"

            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmEstacionTrab_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Estaciones")
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT ESTACION FROM GCESTACIONES ORDER BY ESTACION"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("ESTACION"))
            Loop
            dr.Close()
            'Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmEstacionTrabAE.ShowDialog()

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
            FrmEstacionTrabAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCESTACIONES SET STATUS = 'B' WHERE ESTACION = '" & Fg(Fg.Row, 1) & "'"
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
    Private Sub BarExcel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarExcel.Click

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class