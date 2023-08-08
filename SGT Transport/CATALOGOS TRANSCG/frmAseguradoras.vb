Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmAseguradoras
    Private Sub frmAseguradoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

            Fg.Rows.Count = 1
            Fg.Cols.Count = 24

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "RFC"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Dirección"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "NUm. Int."
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Num. Ext."
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Cruzamientos"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Cruzamientos 2"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Colonia"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "C.P."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg(0, 12) = "Localidad"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "Municipio"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)

            Fg(0, 14) = "Estado"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(String)

            Fg(0, 15) = "Pais"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(String)

            Fg(0, 16) = "Nacionalidad"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(String)

            Fg(0, 17) = "Referencia dir."
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(String)

            Fg(0, 18) = "Teléfono"
            Dim c18 As Column = Fg.Cols(18)
            c18.DataType = GetType(String)

            Fg(0, 19) = "Clasific."
            Dim c19 As Column = Fg.Cols(19)
            c19.DataType = GetType(String)

            Fg(0, 20) = "FAX"
            Dim c20 As Column = Fg.Cols(20)
            c20.DataType = GetType(String)

            Fg(0, 21) = "Pagina web"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(String)

            Fg(0, 22) = "CURP"
            Dim c22 As Column = Fg.Cols(22)
            c22.DataType = GetType(String)

            Fg(0, 23) = "Zona"
            Dim c23 As Column = Fg.Cols(23)
            c23.DataType = GetType(String)

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

            SQL = "SELECT CLAVE, STATUS, NOMBRE, RFC, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO, LOCALIDAD, MUNICIPIO, ESTADO, " &
                "PAIS, NACIONALIDAD, REFERDIR, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA " &
                "FROM GCASEGURADORAS"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("STATUS") & vbTab & dr("NOMBRE") & vbTab & dr("RFC") & vbTab & dr("CALLE") & vbTab &
                           dr("NUMINT") & vbTab & dr("NUMEXT") & vbTab & dr("CRUZAMIENTOS") & vbTab & dr("CRUZAMIENTOS2") & vbTab & dr("COLONIA") & vbTab &
                           dr("CODIGO") & vbTab & dr("LOCALIDAD") & vbTab & dr("MUNICIPIO") & vbTab & dr("ESTADO") & vbTab & dr("PAIS") & vbTab &
                           dr("NACIONALIDAD") & vbTab & dr("REFERDIR") & vbTab & dr("TELEFONO") & vbTab & dr("CLASIFIC") & vbTab & dr("FAX") & vbTab &
                           dr("PAG_WEB") & vbTab & dr("CURP") & vbTab & dr("CVE_ZONA"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmAseguradoras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Aseguradoras")
        Me.Dispose()
    End Sub

    Private Sub frmAseguradoras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

            'frmAseguradorasAE.ShowDialog()
            CREA_TAB(frmAseguradorasAE, "Movimiento Aseguradoras")

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

            CREA_TAB(frmAseguradorasAE, "Movimiento Aseguradoras")

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCASEGURADORAS SET STATUS = 'B' WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"
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

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "ASEGURADORAS")
        Catch ex As Exception
        End Try
    End Sub
End Class
