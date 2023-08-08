Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid


Public Class frmBancos

    Private Sub frmBancos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        CloseTab("Bancos")
        Me.Dispose()
    End Sub

    Private Sub frmBancos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

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

    Private Sub frmBancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(MenuBarra, "F5 - Salir")

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 18

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "CVE_BANCO"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "STATUS"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "DESCR"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "CALLE"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "TELEFONO"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "CIUDAD"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "CORREO1"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "CORREO2"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "CORREO3"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "RFC"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "CTA_BANCARIA"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg(0, 12) = "CLABE"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "FECHA_APER"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(DateTime)

            Fg(0, 14) = "EJECUTIVO"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(String)

            Fg(0, 15) = "ALIAS"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(String)

            Fg(0, 16) = "SUCURSAL"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(String)

            Fg(0, 17) = "SALDO"
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

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

            SQL = "SELECT CVE_BANCO, STATUS, DESCR, CALLE, TELEFONO, CIUDAD, CORREO1, CORREO2, CORREO3, RFC, CTA_BANCARIA, CLABE, " &
                "FECHA_APER, EJECUTIVO, ALIAS, SUCURSAL, SALDO " &
                "FROM GCBANCOS"


            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_BANCO") & vbTab & dr("STATUS") & vbTab & dr("DESCR") & vbTab & dr("CALLE") & vbTab &
                           dr("TELEFONO") & vbTab & dr("CIUDAD") & vbTab & dr("CORREO1") & vbTab & dr("CORREO2") & vbTab &
                           dr("CORREO3") & vbTab & dr("RFC") & vbTab & dr("CTA_BANCARIA") & vbTab & dr("CLABE") & vbTab &
                           dr("FECHA_APER") & vbTab & dr("EJECUTIVO") & vbTab & dr("ALIAS") & vbTab & dr("SUCURSAL") & vbTab & dr("SALDO"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click

        Try
            Var1 = "Nuevo"

            frmBancosAE.ShowDialog()

            DESPLEGAR()

        Catch ex As Exception
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click

        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            frmBancosAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If


    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click

        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCBANCOS SET STATUS = 'B' WHERE CVE_BANCO = '" & Fg(Fg.Row, 1) & "'"
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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click

        Try
            Me.Close()
        Catch ex As Exception
            msgbox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

End Class
