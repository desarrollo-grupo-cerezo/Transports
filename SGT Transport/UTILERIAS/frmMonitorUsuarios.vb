Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Public Class frmMonitorUsuarios
    Private CADENA As String
    Private BindingSource2 As BindingSource = New BindingSource
    Private Sub frmMonitorUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()

        If Not Valida_Conexion() Then
            Return
        End If
        Try

            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = "SELECT UltimaEjecucion FROM SistemaSesionesExec WHERE ID = 1"
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        lb.Text = String.Format("Última Actualización: {0}", dr("UltimaEjecucion"))
                    End If
                End Using
            End Using

            SQL = "SELECT 
	                IdSesion				= SS.IdSesion, 
	                Usuario					= CONCAT(SS.Usuario, ' - ', US.NOMBRE),
	                SS.Host,
	                Inicio					= SS.Registro,
	                [Última Actualización]	= SS.Actualizacion,
	                Estatus					= iif(SS.Estatus = 1, 'Activo', 'Inactivo'),	
	                Tiempo					= dbo.fn_formato_tiempo_dhms(SS.Registro, SS.Actualizacion)
                FROM SistemaSesiones SS
                LEFT JOIN GCUSUARIOS US ON US.USUARIO = SS.Usuario
                WHERE SS.Estatus = 1"


            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("IdSesion") & vbTab & dr("Usuario") & vbTab & dr("Host") & vbTab & dr("Inicio") & vbTab & dr("Última Actualización") & vbTab & dr("Estatus") & vbTab & dr("Tiempo"))
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmMonitorUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Monitor de Usuarios")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick

        Select Case e.Command.Text.Trim
                Case "Salir"
                Me.Close()
        End Select

    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As ClickEventArgs) Handles btnEjecutar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = "EXEC dbo.sp_Sesiones"
                cmd.ExecuteNonQuery()
            End Using

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
