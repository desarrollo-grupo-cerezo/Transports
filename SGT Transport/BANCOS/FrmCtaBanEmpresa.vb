Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmCtaBanEmpresa
    Private Sub FrmCtaBanBen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 18

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

            Fg(0, 4) = "Calle"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Teléfono"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Ciudad"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Correo 1"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Correo 2"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Correo 3"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "R.F.C."
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Cuenta bancaria"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg(0, 12) = "CLABE"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "Fecha apertura"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(DateTime)

            Fg(0, 14) = "Ejecutivo"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(String)

            Fg(0, 15) = "Alias"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(String)

            Fg(0, 16) = "Sucursal"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(String)

            Fg(0, 17) = "Saldo"
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT CLAVE, ISNULL(STATUS,'A') AS ST, NOMBRE_BANCO AS NOMBRE, CALLE, TELEFONO, CIUDAD, CORREO1, CORREO2, CORREO3, 
                RFC_BANCO AS RFC, CUENTA_BANCARIA, CLABE, FECHA_APER, EJECUTIVO, ALIAS, SUCURSAL, SALDO
                FROM CUENTA_BENEF" & Empresa & " 
                WHERE ISNULL(STATUS,'A') <> 'B'
                Order By TRY_PARSE(CLAVE AS INT)"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("ST") & vbTab & dr("NOMBRE") & vbTab & dr("CALLE") & vbTab &
                           dr("TELEFONO") & vbTab & dr("CIUDAD") & vbTab & dr("CORREO1") & vbTab & dr("CORREO2") & vbTab &
                           dr("CORREO3") & vbTab & dr("RFC") & vbTab & dr("CUENTA_BANCARIA") & vbTab & dr("CLABE") & vbTab &
                           dr("FECHA_APER") & vbTab & dr("EJECUTIVO") & vbTab & dr("ALIAS") & vbTab & dr("SUCURSAL") & vbTab & dr("SALDO"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmCtaBanBen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Cuenta bancaria de la empresa")
        Me.Dispose()
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"

            FrmCtaBanEmpresaAE.ShowDialog()

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

            FrmCtaBanEmpresaAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE CUENTA_BENEF" & Empresa & " SET STATUS = 'B' WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"
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
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
