Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmAlmacenes
    Private Sub frmAlmacenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 11

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Núm. almacén"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "Descripción"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Dirección"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Encargado"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Teléfono"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Lista de precios"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Int32)

            Fg(0, 7) = "Cuenta contable"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Movimiento entrada"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Int32)

            Fg(0, 9) = "Movimiento salida"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Int32)

            Fg(0, 10) = "Estatus"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

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

            SQL = "SELECT CVE_ALM, DESCR, DIRECCION, ENCARGADO, TELEFONO, LISTA_PREC, CUEN_CONT, CVE_MENT, 
                CVE_MSAL, ISNULL(STATUS,'A') AS ST
                FROM ALMACENES" & Empresa & " WHERE ISNULL(STATUS,'A') = 'A'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_ALM") & vbTab & dr("DESCR") & vbTab & dr("DIRECCION") & vbTab & dr("ENCARGADO") & vbTab &
                           dr("TELEFONO") & vbTab & dr("LISTA_PREC") & vbTab & dr("CUEN_CONT") & vbTab & dr("CVE_MENT") & vbTab &
                           dr("CVE_MSAL") & vbTab & IIf(dr("ST") = "A", "Activo", "Baja"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

            Fg.Focus()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAlmacenes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Almacenes")
        Me.Dispose()
    End Sub

    Private Sub frmAlmacenes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    BarSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
            msgbox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            Var2 = Fg(Fg.Rows.Count - 1, 1)
            Try
                Var2 = Val(Var2) + 1
            Catch ex As Exception
            End Try

            'Dim mycol As New MyBackGroundColors
            'mycol.DoSet(Me)
            'Dim frm1 As New FrmAlmacenesAE
            'mycol.DoSet(frm1) 'and than this for every form you create.
            'frm1.Show()
            CREA_TAB(FrmAlmacenesAE, "Almacén")
            'FrmAlmacenesAE.ShowDialog()
            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click

        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            CREA_TAB(FrmAlmacenesAE, "Almacén")
            'FrmAlmacenesAE.ShowDialog()
            'DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click

        Try
            If MsgBox("Realmente desea eliminar el almacen?", vbYesNo) = vbYes Then
                SQL = "UPDATE ALMACENES" & Empresa & " SET STATUS = 'B' WHERE CVE_ALM = " & Fg(Fg.Row, 1)
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

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Almacenes")
    End Sub
End Class
