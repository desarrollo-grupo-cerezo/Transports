Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmCXC

    Private Sub frmCXC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Conceptos Cuentas X Cobrar")
        Me.Dispose()
    End Sub

    Private Sub frmCXC_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmCXC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

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

            Fg(0, 1) = "Num. cpto."
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Descripción"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Tipo"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Cuenta contable"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Con referencia"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Gen. concepto"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Int32)

            Fg(0, 7) = "Autorización"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Es forma de pago"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Estatus"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Forma pago SAT"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

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

            SQL = "SELECT NUM_CPTO, DESCR, TIPO, CUEN_CONT, CON_REFER, GEN_CPTO, AUTORIZACION, ES_FMA_PAG, STATUS, FORMADEPAGOSAT " &
                "FROM CONC" & Empresa & " WHERE STATUS = 'A'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("NUM_CPTO") & vbTab & dr("DESCR") & vbTab & IIf(dr("TIPO") = "C", "Cargo", "Abono") & vbTab & dr("CUEN_CONT") & vbTab &
                           dr("CON_REFER") & vbTab & dr("GEN_CPTO") & vbTab & dr("AUTORIZACION") & vbTab & dr("ES_FMA_PAG") & vbTab &
                           dr("STATUS") & vbTab & dr("FORMADEPAGOSAT"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"


            frmCXCAE.ShowDialog()

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


            frmCXCAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                SQL = "UPDATE CONC" & Empresa & " SET STATUS = 'B' WHERE NUM_CPTO = " & Fg(Fg.Row, 1)

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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
