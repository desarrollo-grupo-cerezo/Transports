Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class FrmBBenef
    Private Sub FrmBBenef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.WindowState = FormWindowState.Maximized

            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Tab1.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg2.Dock = DockStyle.Fill

            TITULOS()

            DESPLEGAR()

        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE
            'SELECT CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO, CLAVE FROM CUENTA_BENEF" & Empresa & " 

            SQL = "SELECT CUENTA, RFC_BANCO, BANCO, CLAVE, B.CUENTA, C.CLABE 
                FROM BBENEF
                LEFT JOIN CUENTA_ORD" & Empresa & " C ON C.CUENTA_BANCARIA = B.CUENTA
                ORDER BY TRY_PARSE(B.CLAVE AS INT) "
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Fg2.Rows.Count = 1
            Do While dr.Read
                If dr("ST") = "A" Then
                    Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("NOMBRE") & vbTab & dr("RFC") & vbTab & dr("CTA_CONTAB") & vbTab &
                           dr("TIPO") & vbTab & dr("REFERENCIA") & vbTab & dr("CUENTA") & vbTab & dr("CLABE"))
                Else
                    Fg2.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("NOMBRE") & vbTab & dr("RFC") & vbTab & dr("CTA_CONTAB") & vbTab &
                           dr("TIPO") & vbTab & dr("REFERENCIA") & vbTab & dr("CUENTA") & vbTab & dr("CLABE"))
                End If
            Loop
            dr.Close()
            Fg.AutoSizeCols()
            Fg2.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Fg2.Redraw = True
    End Sub
    Private Sub FrmBBenef_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Beneficiarios")
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmBBenefAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            FrmBBenefAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE BBENEF SET STATUS = 'B' WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"
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
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Beneficiarios")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 13 Then
                    BarEdit_Click(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                BarEdit_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub TITULOS()
        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 9

            Fg.Rows(0).Height = 40
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Nombre"
            Dim cc2 As Column = Fg.Cols(2)
            cc2.DataType = GetType(String)

            Fg(0, 3) = "RFC"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Cuenta contable"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Tipo"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Referencia"
            Dim c7 As Column = Fg.Cols(6)
            c7.DataType = GetType(String)

            Fg(0, 7) = "Cuenta"
            Dim c10 As Column = Fg.Cols(7)
            c10.DataType = GetType(String)

            Fg(0, 8) = "Clabe"
            Dim c11 As Column = Fg.Cols(8)
            c11.DataType = GetType(String)

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Try
            Fg2.Rows.Count = 1
            Fg2.Cols.Count = 9

            Fg2.Rows(0).Height = 40
            'Fg2.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg2.Height = Me.Height - 150

            Fg2(0, 1) = "Clave"
            Dim cc1 As Column = Fg2.Cols(1)
            cc1.DataType = GetType(String)

            Fg2(0, 2) = "Nombre"
            Dim cc2 As Column = Fg2.Cols(2)
            cc2.DataType = GetType(String)

            Fg2(0, 3) = "RFC"
            Dim c3 As Column = Fg2.Cols(3)
            c3.DataType = GetType(String)

            Fg2(0, 4) = "Cuenta contable"
            Dim c4 As Column = Fg2.Cols(4)
            c4.DataType = GetType(String)

            Fg2(0, 5) = "Tipo"
            Dim c5 As Column = Fg2.Cols(5)
            c5.DataType = GetType(String)

            Fg2(0, 6) = "Referencia"
            Dim c7 As Column = Fg2.Cols(6)
            c7.DataType = GetType(String)

            Fg2(0, 7) = "Cuenta"
            Dim c10 As Column = Fg2.Cols(7)
            c10.DataType = GetType(String)

            Fg2(0, 8) = "Clabe"
            Dim c11 As Column = Fg2.Cols(8)
            c11.DataType = GetType(String)

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try


    End Sub

End Class
