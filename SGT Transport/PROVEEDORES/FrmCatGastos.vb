
Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid

Public Class FrmCatGastos
    Private Sub FrmCatGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Fg.Dock = DockStyle.Fill
        Catch ex As Exception
        End Try

        Try

            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 10

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Gasto"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Linea"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Esquema"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha ult. gasto"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "Ult. documento"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Costo"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Cuenta contable"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

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

            SQL = "SELECT G.CVE_ART, G.STATUS, G.DESCR, G.LINEA, G.CVE_ESQIMPU, FECHA_ULTG, ULT_DOCG, 
                COSTO, DESCRIPESQ, CUENTA_CONT
                FROM GCCATGASTOS G
                LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = G.CVE_ESQIMPU
                WHERE G.STATUS = 'A'
                ORDER BY G.CVE_ART"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_ART") & vbTab & dr("STATUS") & vbTab & dr("DESCR") & vbTab &
                           dr("LINEA") & vbTab & dr("DESCRIPESQ") & vbTab & dr("FECHA_ULTG") & vbTab &
                           dr("ULT_DOCG") & vbTab & dr("COSTO") & vbTab & dr("CUENTA_CONT"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1)
                FrmCatGastosAE.ShowDialog()
                DESPLEGAR()
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCCATGASTOS SET STATUS = 'B' WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "'"
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
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmCatGastosAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmCatGastos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Cat. gastos")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Catalogo de gastos")
    End Sub
End Class