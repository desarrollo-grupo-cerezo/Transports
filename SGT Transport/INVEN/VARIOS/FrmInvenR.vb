Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmInvenR
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private ParamCadena As String

    Private Sub frmInvenR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            ParamCadena = " STATUS = 'A'"
            Application.DoEvents()

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
            SQL = "SELECT CVE_ART, STATUS, (SELECT TOP 1 CVE_ALTER FROM GCCVES_ALTER A WHERE CVE_ART = I.CVE_ART) AS NO_PARTE, ISNULL(DESCR, '') AS DES, " &
                "ISNULL(LIN_PROD,'') AS LIN, ISNULL(CON_SERIE,'') AS C_SERIE, ISNULL(UNI_MED,'') AS U_MED, ISNULL(UNI_EMP,'') AS U_EMP, " &
                "ISNULL(CTRL_ALM,'') AS C_ALM, ISNULL(TIEM_SURT,'') AS T_SURT, ISNULL(STOCK_MIN,0) AS S_MIN, ISNULL(STOCK_MAX,0) AS S_MAX, " &
                "TIP_COSTEO, " &
                "ISNULL(NUM_MON,1) AS N_MON, ISNULL(PEND_SURT,'') AS P_SURT, ISNULL(EXIST,0) AS EXI, ISNULL(COSTO_PROM,0) AS C_PROM, " &
                "ISNULL(ULT_COSTO,0) AS U_COSTO, CVE_OBS, TIPO_ELE, UNI_ALT, FAC_CONV, APART, CON_LOTE, CON_PEDIMENTO, PESO, VOLUMEN, " &
                "CVE_ESQIMPU, CVE_PRODSERV, CVE_UNIDAD " &
                "FROM GCINVER I WHERE " & ParamCadena & " ORDER BY DESCR"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120


            da.Fill(dt)
            BindingSource1.DataSource = dt
            Application.DoEvents()
            Application.DoEvents()
            Fg.DataSource = BindingSource1.DataSource
            Lt.Text = "Registros encontrados: " & Fg.Rows.Count - 1

            ENCABEZADO()

            Fg.AutoSizeCols()
            'Fg.AllowEditing = True
            Fg.Redraw = True

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ENCABEZADO()

        Fg.Cols.Count = 33

        Fg.Rows(0).Height = 31
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 150

        Fg(0, 1) = "Artículo"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(String)

        Fg(0, 2) = "Estatus"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "No. Parte"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Descripción"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)

        Fg(0, 5) = "Linea"
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "Con serie"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(String)

        Fg(0, 7) = "Unidad medida"
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(String)

        Fg(0, 8) = "Unidad alternativa"
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Control almacén"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(String)

        Fg(0, 10) = "Tiempo surtido"
        Dim c10 As Column = Fg.Cols(10)
        c10.DataType = GetType(Int32)

        Fg(0, 11) = "Stock min."
        Dim c11 As Column = Fg.Cols(11)
        c11.DataType = GetType(Decimal)
        Fg.Cols(11).Format = "###,###,##0.00"

        Fg(0, 12) = "Stock max."
        Dim c12 As Column = Fg.Cols(12)
        c12.DataType = GetType(Decimal)
        Fg.Cols(12).Format = "###,###,##0.00"

        Fg(0, 13) = "Tipo costeo"
        Dim c13 As Column = Fg.Cols(13)
        c13.DataType = GetType(String)

        Fg(0, 14) = "Moneda"
        Dim c14 As Column = Fg.Cols(14)
        c14.DataType = GetType(Int32)

        Fg(0, 15) = "Pendientes x surtir"
        Dim c15 As Column = Fg.Cols(15)
        c15.DataType = GetType(Decimal)
        Fg.Cols(15).Format = "###,###,##0.00"

        Fg(0, 16) = "Existencia"
        Dim c16 As Column = Fg.Cols(16)
        c16.DataType = GetType(Decimal)
        Fg.Cols(16).Format = "###,###,##0.00"

        Fg(0, 17) = "Costo prom."
        Dim c17 As Column = Fg.Cols(17)
        c17.DataType = GetType(Decimal)
        Fg.Cols(17).Format = "###,###,##0.00"

        Fg(0, 18) = "ULt. costo"
        Dim c18 As Column = Fg.Cols(18)
        c18.DataType = GetType(Decimal)
        Fg.Cols(18).Format = "###,###,##0.00"

        Fg(0, 19) = "Observaciones"
        Dim c19 As Column = Fg.Cols(19)
        c19.DataType = GetType(Int32)

        Fg(0, 20) = "Tipo elemento"
        Dim c20 As Column = Fg.Cols(20)
        c20.DataType = GetType(String)

        Fg(0, 21) = "Unidad alterna"
        Dim c21 As Column = Fg.Cols(21)
        c21.DataType = GetType(String)

        Fg(0, 22) = "Factor de conv."
        Dim c22 As Column = Fg.Cols(22)
        c22.DataType = GetType(Decimal)
        Fg.Cols(22).Format = "###,###,##0.00"

        Fg(0, 23) = "Apartados"
        Dim c23 As Column = Fg.Cols(23)
        c23.DataType = GetType(Decimal)
        Fg.Cols(23).Format = "###,###,##0.00"

        Fg(0, 24) = "Con lote"
        Dim c24 As Column = Fg.Cols(24)
        c24.DataType = GetType(String)

        Fg(0, 25) = "Con pedimento"
        Dim c25 As Column = Fg.Cols(25)
        c25.DataType = GetType(String)

        Fg(0, 26) = "Peso"
        Dim c26 As Column = Fg.Cols(26)
        c26.DataType = GetType(Decimal)
        Fg.Cols(26).Format = "###,###,##0.00"

        Fg(0, 27) = "Volumen"
        Dim c27 As Column = Fg.Cols(27)
        c27.DataType = GetType(Decimal)
        Fg.Cols(27).Format = "###,###,##0.00"

        Fg(0, 28) = "Esquema"
        Dim c28 As Column = Fg.Cols(28)
        c28.DataType = GetType(Int32)

        Fg(0, 29) = "Clave SAT"
        Dim c29 As Column = Fg.Cols(29)
        c29.DataType = GetType(String)

        Fg(0, 30) = "Unidad SAT"
        Dim c30 As Column = Fg.Cols(30)
        c30.DataType = GetType(String)

    End Sub
    Private Sub frmInvenR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Inventario Refacciones")
        Me.Dispose()
    End Sub

    Private Sub frmInvenR_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            frmInvenRAE.ShowDialog()
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

            frmInvenRAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub barPrecios_Click(sender As Object, e As EventArgs) Handles barPrecios.Click
        CREA_TAB(frmPreciosGC, "Precios Refacciones")
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCINVER SET STATUS = 'B' WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 120

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
    Private Sub barRefresh_Click(sender As Object, e As EventArgs) Handles barRefresh.Click
        ParamCadena = " STATUS = 'A'"
        DESPLEGAR()
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCINVER SET STATUS = 'B' WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 120

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
    Private Sub barKits_Click(sender As Object, e As EventArgs) Handles barKits.Click
        ParamCadena = " STATUS = 'A' AND TIPO_ELE = 'K'"
        DESPLEGAR()
    End Sub
    Private Sub barBaja_Click(sender As Object, e As EventArgs) Handles barBaja.Click
        ParamCadena = "STATUS = 'B'"
        DESPLEGAR()
    End Sub
    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            SQL = "(CVE_ART LIKE '%" & tBox.Text & "%' OR DES LIKE '%" & tBox.Text & "%' OR " &
                "NO_PARTE LIKE '%" & tBox.Text & "%' OR LIN LIKE '%" & tBox.Text & "%')"
            BindingSource1.Sort = "CVE_ART"

            BindingSource1.RemoveFilter()

            If tBox.Text.Trim.Length > 0 Then
                BindingSource1.Filter = SQL
            Else
                BindingSource1.Filter = ""
            End If
            Fg.DataSource = BindingSource1.DataSource

        Catch ex As Exception
            msgbox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barKardex_Click(sender As Object, e As EventArgs) Handles barKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1)
                Var5 = Fg(Fg.Row, 4)
                frmKardex.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
