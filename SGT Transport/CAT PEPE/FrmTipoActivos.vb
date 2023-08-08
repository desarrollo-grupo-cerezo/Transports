Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win

Public Class FrmTipoActivos
    Private Sub FrmTipoActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try

            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 12

            Fg.Rows(0).Height = 60
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 150
            Fg.Dock = DockStyle.Fill
            Fg.Styles.Fixed.WordWrap = True

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int16)

            Fg(0, 2) = "Descripción"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Tasa contable" '"DEDNORMAL"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Tasa fiscal" '"DEDIMED"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Máxima deducible" '"MAXDED"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Método de depreciación"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Depreciación proyectada"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "p"

            Fg(0, 8) = "Cuenta del activo"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Depreciación del activo"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Gastos depreciación"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Baja o venta de activos"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)


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

            SQL = "SELECT CLAVE, DESCRIP, DEDNORMAL, DEDIMED, MAXDED, DEPPROY, CTAAACTV, CTADEPRE, CTAGASTOS, CTAPERGAN, 
                CASE 
                WHEN METODODEP = 'L' THEN 'Linea recta' 
                WHEN METODODEP = 'D' THEN 'Doble saldo declinante' 
                WHEN METODODEP = 'S' THEN 'Suma de años dígitos' ELSE '' END AS METODO
                FROM GCTIPACTIV"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("DESCRIP") & vbTab & dr("DEDNORMAL") & vbTab & dr("DEDIMED") & vbTab &
                            dr("MAXDED") & vbTab & dr("METODO") & vbTab & dr("DEPPROY") & vbTab & dr("CTAAACTV") & vbTab &
                            dr("CTADEPRE") & vbTab & dr("CTAGASTOS") & vbTab & dr("CTAPERGAN"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()
            Fg.Cols(5).Width = 60
            Fg.Cols(6).Width = 70
            Fg.Cols(7).Width = 75
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmTipoActivos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Tipo Activos")
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"

            'Dim f As New FrmTipoActivosAE With {
            '.MdiParent = MainRibbonForm.ActiveForm}
            'f.ShowDialog()

            Dim f As New FrmTipoActivosAE()
            f.MdiParent = MainRibbonForm.Owner
            f.ShowDialog()


            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            Dim f As New FrmTipoActivosAE()
            f.MdiParent = MainRibbonForm.Owner
            f.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCTIPACTIV SET STATUS = 'B' WHERE  CLAVE = " & Fg(Fg.Row, 1)
                Dim cmd As New SqlCommand With {.Connection = cnSAE, .CommandText = SQL}
                returnValue = cmd.ExecuteNonQuery().ToString
                If Not returnValue Is Nothing Then
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
    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "TIPO ACTIVOS")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class