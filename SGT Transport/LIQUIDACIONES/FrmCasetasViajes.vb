Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmCasetasViajes

    Public ViajesDisponibles As List(Of String)
    Public ViajesSelecionados As List(Of String)
    Private Sub FrmCasetasViajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToScreen()

            DESPLEGAR()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmCasetasViajes_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub
    Sub DESPLEGAR()

        Fg.Rows.Count = 1

        Try

            For Each viaje In ViajesDisponibles

                Dim seleccionado As Boolean
                seleccionado = ViajesSelecionados.Where(Function(x) x = viaje).Any()

                Fg.AddItem("" & vbTab & seleccionado & vbTab & viaje)
            Next

            'Fg.AutoSizeCols()

            If Fg.Rows.Count = 1 Then
                MsgBox("No se encontraron viajes disponibles")
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmCasetasViajes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click

        ViajesSelecionados = New List(Of String)

        For k = 1 To Fg.Rows.Count - 1
            If Fg(k, 1) Then
                ViajesSelecionados.Add(Fg(k, 2))
            End If
        Next
        DialogResult = DialogResult.OK
        Me.Close()


    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
