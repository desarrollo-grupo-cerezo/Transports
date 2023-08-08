Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMarcasLlantas

    Private Sub frmMarcasLlantas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        CloseTab("Marcas Llantas")
        Me.Dispose()
    End Sub

    Private Sub frmMarcasLlantas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

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


    Private Sub frmMarcasLlantas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try

            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")


            Fg.Rows.Count = 1
            Fg.Cols.Count = 5

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Tipo"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Int16)


            Fg.Cols(1).AllowEditing = False
            Fg.Cols(2).AllowEditing = False
            Fg.Cols(3).AllowEditing = False
            Fg.Cols(4).AllowEditing = False

            DESPLEGAR()

        Catch ex As Exception
            msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
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

            SQL = "SELECT M.CVE_MARCA, M.STATUS, M.DESCR, ISNULL(T.DESCR,'') AS DESCR_TIPO " &
                "FROM GCMARCAS M " &
                "LEFT JOIN GCLLANTA_TIPO T ON T.CVE_TIPO = M.TIPO"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_MARCA") & vbTab & dr("STATUS") & vbTab & dr("DESCR") & vbTab & dr("DESCR_TIPO"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("3. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("3. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click

        Try
            Var1 = "Nuevo"

            frmMarcasLLantasAE.ShowDialog()

            DESPLEGAR()

        Catch ex As Exception
            msgbox("4. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click

        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            frmMarcasLLantasAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If

    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click

        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                SQL = "UPDATE GCMARCAS SET STATUS = 'B' WHERE CVE_MARCA = '" & Fg(Fg.Row, 1) & "'"
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
            msgbox("5. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("5. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click

        Try
            Me.Close()
        Catch ex As Exception
            msgbox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
End Class
