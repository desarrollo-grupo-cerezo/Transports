Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmMotores
    Private Sub frmMotores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Try

            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 5

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Motor"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Tipo viaje"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT CVE_MOT, MOTOR, DESCR, CASE 
                   WHEN TIPO_VIAJE = 0 THEN 'Full' 
                   WHEN TIPO_VIAJE = 1 THEN 'Sencillo'
                   WHEN TIPO_VIAJE = 2 THEN 'Full/Sencillo' ELSE '' END AS TIP_VIAJE FROM GCMOTORES WHERE STATUS = 'A'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_MOT") & vbTab & dr("MOTOR") & vbTab & dr("DESCR") & vbTab & dr("TIP_VIAJE"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmMotores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Motores")
        Me.Dispose()
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmMotoresAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmMotoresAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                If IsNumeric(Fg(Fg.Row, 1)) Then
                    SQL = "UPDATE GCMOTORES SET STATUS = 'B' WHERE CVE_MOT = " & Fg(Fg.Row, 1)
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
                Else
                    MsgBox("Por favor seleccione un registros")
                End If
            Else
                MsgBox("Por favor seleccione un registros")
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
