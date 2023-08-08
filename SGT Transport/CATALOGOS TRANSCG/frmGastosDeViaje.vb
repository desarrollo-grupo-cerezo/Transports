
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmGastosDeViaje
    Private Sub frmGastosDeViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try

            Me.WindowState = FormWindowState.Maximized
            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 14

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Operador"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Viaje"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Unidad"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Fecha"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Fg(0, 6) = "Fecha elab."
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "Proveedor"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Concpeto"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Int16)

            Fg(0, 9) = "Clave aut."
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Gen.pas."
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Int16)

            Fg(0, 11) = "Litros"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Unidad 2"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "Total comb."
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"


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
            Fg.Cols(12).AllowEditing = False
            Fg.Cols(13).AllowEditing = False

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

            SQL = "SELECT CVE_NUM, CVE_OPER, CVE_VIAJE, CVE_UNI, FECHA, FECHAELAB, CVE_PROV, NUM_CPTO, CVE_AUT, GEN_PAS, LITROS, CVE_UNI2, TOTAL_COMB " &
                "FROM GCGASTOS_VIAJE WHERE STATUS = 'A'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_NUM") & vbTab & dr("CVE_OPER") & vbTab & dr("CVE_VIAJE") & vbTab & dr("CVE_UNI") & vbTab &
                           dr("FECHA") & vbTab & dr("FECHAELAB") & vbTab & dr("CVE_PROV") & vbTab & dr("NUM_CPTO") & vbTab & dr("CVE_AUT") & vbTab &
                           dr("GEN_PAS") & vbTab & dr("LITROS") & vbTab & dr("CVE_UNI2") & vbTab & dr("TOTAL_COMB"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmGastosDeViaje_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Gastos de Viajes")
        Me.Dispose()
    End Sub

    Private Sub frmGastosDeViaje_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            'frmGastosDeViajeAE.ShowDialog()
            CREA_TAB(frmGastosDeViajeAE, "Gastos de Viaje")
            'DESPLEGAR()
        Catch ex As Exception
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            'frmGastosDeViajeAE.ShowDialog()
            CREA_TAB(frmGastosDeViajeAE, "Gastos de Viaje")
            'DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCGASTOS_VIAJE SET STATUS = 'B' WHERE CVE_NUM = '" & Fg(Fg.Row, 1) & "'"
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
