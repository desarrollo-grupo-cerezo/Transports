Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmValeCombustibleEfectivo
    Private PassDataForm As String
    Private Sub frmValeCombustible_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try
            PassDataForm = PassData
            Me.Text = PassDataForm


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

            Fg(0, 1) = "Folio"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Fecha"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(DateTime)

            Fg(0, 4) = "FECHA_VALE"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(DateTime)

            Fg(0, 5) = "FECHA_CARGA"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Fg(0, 6) = "VALE_GAS"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "CVE_UNI"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "CVE_GAS"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "CVE_CAR"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "PRECIO"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "IMPORTE"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "LITROS"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "LITROS_REAL"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "CVE_OBS"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Int32)


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
            Fg.Cols(14).AllowEditing = False

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

            SQL = "SELECT CVE_FOLIO, STATUS, FECHA, FECHA_VALE, FECHA_CARGA, VALE_GAS, CVE_UNI, CVE_GAS, CVE_CAR, PRECIO, IMPORTE, LITROS, " &
                "LITROS_REAL, CVE_OBS " &
                "FROM GCVALE_COMBUSTIBLE WHERE STATUS = 'A' AND TIPO = 'FC'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_FOLIO") & vbTab & dr("STATUS") & vbTab & dr("FECHA_VALE") & vbTab & dr("FECHA_CARGA") & vbTab &
                           dr("VALE_GAS") & vbTab & dr("CVE_UNI") & vbTab & dr("CVE_GAS") & vbTab & dr("CVE_CAR") & vbTab & dr("PRECIO") & vbTab &
                           dr("IMPORTE") & vbTab & dr("LITROS") & vbTab & dr("LITROS_REAL") & vbTab & dr("CVE_OBS"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmValeCombustible_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Combustible Efectivo")
        Me.Dispose()
    End Sub

    Private Sub frmValeCombustible_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"

            frmValeCombustibleEfectivoAE.ShowDialog()

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

            frmValeCombustibleEfectivoAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCVALE_COMBUSTIBLE SET STATUS = 'B' WHERE CVE_FOLIO = '" & Fg(Fg.Row, 1) & "' " & IIf(PassDataForm = "Vale Combustible", " AND TIPO = 'VC'", " AND TIPO = 'FC'")
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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

End Class
