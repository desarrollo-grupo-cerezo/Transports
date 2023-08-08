Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmSiniestro
    Private Sub frmSiniestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 15

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "FOLIO"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "NUM_SIN"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Int32)

            Fg(0, 3) = "STATUS"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "FECHA"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(DateTime)

            Fg(0, 5) = "IDPOLIZA"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Int32)

            Fg(0, 6) = "HORA"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "CVE_UNI"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "CVE_OPER"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "UBICACION"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "LATITUD"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Int32)

            Fg(0, 11) = "LONGITUD"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Int32)

            Fg(0, 12) = "FECHA_ATENCION"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(DateTime)

            Fg(0, 13) = "HORA_ATENCION"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(DateTime)

            Fg(0, 14) = "DESCR"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(String)

            DESPLEGAR()
        Catch ex As Exception
            msgbox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim NOMBRE As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT S.FOLIO, S.NUM_SIN, S.STATUS, S.FECHA, S.IDPOLIZA, S.HORA, U.DESCR AS UNIDAD, O.NOMBRE, S.UBICACION, S.LATITUD, S.LONGITUD, " &
                "FECHA_ATENCION, HORA_ATENCION, S.DESCR " &
                "FROM GCSINIESTRO S " &
                "LEFT JOIN GCUNIDADES U ON U.CLAVE = S.CVE_UNI " &
                "LEFT JOIN GCOPERADOR O ON O.CLAVE = S.CVE_OPER "

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read

                NOMBRE = dr("NOMBRE")

                Fg.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("NUM_SIN") & vbTab & dr("STATUS") & vbTab & dr("FECHA") & vbTab &
                           dr("IDPOLIZA") & vbTab & dr("HORA") & vbTab & dr("UNIDAD") & vbTab & NOMBRE & vbTab &
                           dr("UBICACION") & vbTab & dr("LATITUD") & vbTab & dr("LONGITUD") & vbTab & dr("FECHA_ATENCION") & vbTab &
                           dr("HORA_ATENCION") & vbTab & dr("DESCR"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmSiniestro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Siniestros")
        Me.Dispose()
    End Sub

    Private Sub frmSiniestro_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            msgbox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmSiniestroAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmSiniestroAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCSINIESTRO SET STATUS = 'B' WHERE CVE_OPER = '" & Fg(Fg.Row, 1) & "'"
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
            msgbox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
