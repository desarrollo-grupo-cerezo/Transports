
Public Class frmTractosMov


    Private Sub frmTractosMov_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Application.EnableVisualStyles()


    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click

        Me.Close()

    End Sub

    Private Sub barGuardar_Click(sender As Object, e As EventArgs) Handles barGuardar.Click




    End Sub
End Class
