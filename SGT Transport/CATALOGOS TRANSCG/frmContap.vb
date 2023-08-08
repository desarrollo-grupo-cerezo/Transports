Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmContap
    Private Sub frmContap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 12

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Num. Contrato"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "Provedor"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Dirección"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Telefono"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Correo"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Tipo contacto"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Estatus"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Usuario"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "LAT"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"
            c10.Visible = False
            Fg(0, 11) = "LON"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"
            c11.Visible = False

            Fg.Cols(1).AllowEditing = False
            Fg.Cols(2).AllowEditing = False
            Fg.Cols(3).AllowEditing = False
            Fg.Cols(4).AllowEditing = False
            Fg.Cols(5).AllowEditing = False
            Fg.Cols(6).AllowEditing = False
            Fg.Cols(7).AllowEditing = False
            Fg.Cols(8).AllowEditing = False
            Fg.Cols(9).AllowEditing = False
            Fg.Cols(10).AllowEditing = False
            Fg.Cols(11).AllowEditing = False

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

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT NCONTACTO, CVE_PROV, NOMBRE, DIRECCION, TELEFONO, EMAIL, TIPOCONTAC, STATUS, USUARIO, LAT, LON FROM CONTAP01"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("NCONTACTO") & vbTab & dr("CVE_PROV") & vbTab & dr("NOMBRE") & vbTab & dr("DIRECCION") & vbTab & dr("TELEFONO") & vbTab & dr("EMAIL") & vbTab & dr("TIPOCONTAC") & vbTab & dr("STATUS") & vbTab & dr("USUARIO") & vbTab & dr("LAT") & vbTab & dr("LON"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmContap_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Contactos Proveedores")
        Me.Dispose()
    End Sub

    Private Sub frmContap_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            frmContapAE.ShowDialog()
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
            frmContapAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "DELETE FROM CONTAP" & Empresa & " WHERE NCONTACTO = " & Fg(Fg.Row, 1)
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
