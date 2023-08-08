Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmMultiAlmacenF
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Dim CADENA As String

    Private Sub frmMultiAlmacenF_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Do While dr.Read
                cboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
            Loop
            dr.Close()
            cboAlmacen.SelectedIndex = 0
        Catch ex As Exception
            Bitacora("0. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("0. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CADENA = " WHERE M.STATUS = 'A'"
        DESPLEGAR()

    End Sub

    Sub DESPLEGAR()
        Try
            SQL = "SELECT M.CVE_ART, M.CVE_ALM, M.STATUS, DESCR, M.CTRL_ALM, M.EXIST, M.STOCK_MIN, M.STOCK_MAX " &
                "FROM MULT" & Empresa & " M " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART " &
                CADENA & "ORDER BY CVE_ALM"
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            TITULOS()
            Fg.AutoSizeCols()
        Catch ex As Exception
            Bitacora("0. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("0. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub TITULOS()
        Fg(0, 1) = "Articulo"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(String)

        Fg(0, 2) = "Almacen"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(Int32)

        Fg(0, 3) = "Estatus"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Descripción"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)

        Fg(0, 5) = "Ctrl. Alm."
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "Exist."
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(Decimal)
        Fg.Cols(6).Format = "###,###,##0.00"

        Fg(0, 7) = "Stock min."
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(Decimal)
        Fg.Cols(7).Format = "###,###,##0.00"

        Fg(0, 8) = "Stock max."
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmMultiAlmacenFAlta.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MessageBox.Show("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            Var3 = Fg(Fg.Row, 2)
            frmMultiAlmacenFAlta.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCMULTF" & Empresa & " SET STATUS = 'B' " &
                    "WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "' AND CVE_ALM = " & Fg(Fg.Row, 2)
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 120

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        CADENA = " WHERE M.STATUS = 'A'"
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

    Private Sub frmMultiAlmacenF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Multialmacén")
        Me.Dispose()

    End Sub

    Private Sub cboAlmacen_Click(sender As Object, e As EventArgs) Handles cboAlmacen.Click
    End Sub

    Private Sub barCrearAlmacenes_Click(sender As Object, e As EventArgs) Handles barCrearAlmacenes.Click
        Var2 = "InvenF"
        frmCrearAlmacenes.ShowDialog()

    End Sub

    Private Sub cboAlmacen_DropDownClosed(sender As Object, e As EventArgs) Handles cboAlmacen.DropDownClosed
        Try
            Dim ALMACEN As Integer
            ALMACEN = 1
            If cboAlmacen.SelectedIndex > -1 Then
                ALMACEN = Val(cboAlmacen.Items(cboAlmacen.SelectedIndex).ToString.Substring(0, 2))
                CADENA = " WHERE CVE_ALM = " & ALMACEN & " AND M.STATUS = 'A'"
                DESPLEGAR()
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barActualizar_Click(sender As Object, e As EventArgs) Handles barActualizar.Click
        CADENA = " WHERE M.STATUS = 'A'"
        DESPLEGAR()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
