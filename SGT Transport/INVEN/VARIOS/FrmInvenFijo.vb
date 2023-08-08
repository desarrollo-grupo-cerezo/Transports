Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmInvenFijo
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private ParamCadena As String
    Private Sub frmInvenFijo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try

            Me.WindowState = FormWindowState.Maximized
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With

            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.KeyPreview = True

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Application.DoEvents()

            ParamCadena = " STATUS = 'A'"

            ENCABEZADO()
            DESPLEGAR()

            Fg.AutoSizeCols()

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
            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ds As New DataSet

            Fg.Redraw = False
            Fg.AllowEditing = False

            Application.DoEvents()
            SQL = "SELECT CVE_ART, STATUS, DESCR, LIN_PROD, UNI_MED, STOCK_MIN, STOCK_MAX, EXIST, COSTO_PROM, ULT_COSTO " &
                "FROM GCIFIJO WHERE " & ParamCadena & " ORDER BY DESCR"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120


            da.Fill(dt)
            BindingSource1.DataSource = dt
            Application.DoEvents()
            Fg.DataSource = BindingSource1.DataSource
            Lt.Text = "Registros encontrados: " & Fg.Rows.Count - 1

            If ParamCadena.IndexOf("STATUS = 'B'") > -1 Then
                For k = 1 To Fg.Rows.Count - 1

                    If Fg(k, 22) = "K" Then
                        Fg(k, 0) = "-" & k
                    Else
                        Fg(k, 0) = k
                    End If
                Next
            End If

            ENCABEZADO()

            Fg.AutoSizeCols()
            Fg.Redraw = True

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ENCABEZADO()

        Fg.Rows(0).Height = 40
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 150

        Fg(0, 1) = "Artículo"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(String)

        Fg(0, 2) = "Estatus"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Descripción"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Linea"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)

        Fg(0, 5) = "Uni. med."
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "Stock min."
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(Decimal)
        Fg.Cols(6).Format = "###,###,##0.00"

        Fg(0, 7) = "Stock max."
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(Decimal)
        Fg.Cols(7).Format = "###,###,##0.00"

        Fg(0, 8) = "Exist."
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Costo prom."
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(Decimal)
        Fg.Cols(9).Format = "###,###,##0.00"

        Fg(0, 10) = "Ult. costo"
        Dim c10 As Column = Fg.Cols(10)
        c10.DataType = GetType(Decimal)
        Fg.Cols(10).Format = "###,###,##0.00"

    End Sub
    Private Sub frmInvenFijo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Inventario de Activo Fijo")
        Me.Dispose()
    End Sub

    Private Sub frmInvenFijo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
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
            frmInvenFijoAE.ShowDialog()

            ParamCadena = " STATUS = 'A'"
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

            If Fg(Fg.Row, 2) <> "A" Then
                If MsgBox("El registro actualmente se encuentra con estatus baja, Desea recueperarlo?", vbYes) = vbYes Then
                    SQL = "UPDATE GCIFIJO SET STATUS = 'A' WHERE " & ParamCadena & " ORDER BY DESCR"
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnSAE
                    cmd.CommandTimeout = 120

                    cmd.CommandText = SQL

                End If
            End If

            frmInvenFijoAE.ShowDialog()

            ParamCadena = " STATUS = 'A'"
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCIFIJO SET STATUS = 'B' WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        ParamCadena = " STATUS = 'A'"
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
    Private Sub barRefresh_Click(sender As Object, e As EventArgs) Handles barRefresh.Click
        ParamCadena = " STATUS = 'A'"
        DESPLEGAR()
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub barBaja_Click(sender As Object, e As EventArgs) Handles barBaja.Click
        ParamCadena = "STATUS <> 'A'"
        DESPLEGAR()
    End Sub
    Private Sub barPrecios_Click(sender As Object, e As EventArgs) Handles barPrecios.Click
        CREA_TAB(frmPrecios, "Precios inventario fijo")
    End Sub
End Class
