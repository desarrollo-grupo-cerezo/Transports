Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmDescOperador
    Private Sub FrmDescOperador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Fg.Cols.Count = 11

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Folio"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "Fecha"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(DateTime)

            Fg(0, 3) = "Fecha 2"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(DateTime)

            Fg(0, 4) = "Operador"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Concepto"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Int16)

            Fg(0, 6) = "Tipo"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Int32)

            Fg(0, 7) = "Clave for."
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Int32)

            Fg(0, 8) = "Estatus"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Importe"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Observaciones"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Int32)


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

            SQL = "SELECT FOLIO, FECHA1, FECHA2, CVE_OPER, NUM_CPTO, CVE_TIP, CVE_FOR, STATUS, IMPORTE, CVE_OBS " &
                "FROM GCDESC_OPERADOR WHERE STATUS = 'A'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("FECHA1") & vbTab & dr("FECHA2") & vbTab & dr("CVE_OPER") & vbTab &
                           dr("NUM_CPTO") & vbTab & dr("CVE_TIP") & vbTab & dr("CVE_FOR") & vbTab & dr("STATUS") & vbTab &
                           dr("IMPORTE") & vbTab & dr("CVE_OBS"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmDescOperador_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Descuento Operador")
        Me.Dispose()
    End Sub

    Private Sub FrmDescOperador_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    BarEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmDescOperadorAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmDescOperadorAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCDESC_OPERADOR SET STATUS = 'B' WHERE FOLIO = " & Fg(Fg.Row, 1)
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
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "DESCOPERADORES")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
