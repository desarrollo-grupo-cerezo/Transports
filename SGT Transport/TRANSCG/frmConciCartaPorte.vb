Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmConciCartaPorte
    Private Sub frmConciCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.KeyPreview = True


            Fg.Rows.Count = 1
            Fg.Cols.Count = 7

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Folio"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)


            Fg(0, 2) = "Fecha"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(DateTime)

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

            SQL = "SELECT CVE_CCP, CVE_DOC, FECHA_DOC, CLIENTE, NOMBRE, IMPORTE " &
                "FROM GCCONCI_CARTA_PORTE P " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE " &
                "WHERE P.STATUS = 'A' " &
                "ORDER BY FECHAELAB DESC"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_CCP") & vbTab & dr("CVE_DOC") & vbTab & dr("CLIENTE") & vbTab & dr("NOMBRE") & vbTab &
                           dr("FECHA_DOC") & vbTab & dr("IMPORTE"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            If FORM_IS_OPEN(frmConciCartaPorteAE.Name) Then
                frmConciCartaPorteAE.Close()
                frmConciCartaPorteAE.Dispose()
            End If
            frmConciCartaPorteAE.ShowDialog()
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
            frmConciCartaPorteAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCCONCI_CARTA_PORTE SET STATUS = 'B' WHERE CVE_CCP = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se eliminó satisfactoriamente")

                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT CVE_FOLIO FROM GCCONCI_CARTA_PORTE_PAR WHERE CVE_CCP = '" & Fg(Fg.Row, 1) & "'"
                            cmd3.CommandText = SQL
                            Using dr As SqlDataReader = cmd3.ExecuteReader
                                While dr.Read
                                    SQL = "UPDATE GCCARTA_PORTE SET CONCILIADO = 0 WHERE CVE_FOLIO = '" & dr("CVE_FOLIO") & "'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End While
                            End Using
                        End Using

                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "DELETE FROM GCCONCI_CARTA_PORTE_PAR WHERE CVE_CCP = '" & Fg(Fg.Row, 1) & "'"
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub frmConciCartaPorte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Conciliación Cartas Porte")
    End Sub

    Private Sub frmConciCartaPorte_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    barSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class
