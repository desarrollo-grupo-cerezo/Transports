Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmDeducOper
    Private CADENA As String = ""
    Private Sub FrmDeducOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try
            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 6

            SplitContainer1.SplitterWidth = 1
            C1SplitContainer1.SplitterWidth = 1

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

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

            SQL = "SELECT CVE_OPER, MAX(NOMBRE) AS NOMBRE, SUM(IMPORTE_PRESTAMO) AS P1, SUM(IMPORTE_PAGADO) AS P2, SUM(SALDO) AS P3
                FROM GCDEDUC_OPER D
                LEFT JOIN GCOPERADOR O ON O.CLAVE = D.CVE_OPER
                WHERE D.STATUS = 'A' " & CADENA & "
                GROUP BY CVE_OPER ORDER BY D.CVE_OPER"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Redraw = False
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_OPER") & vbTab & dr("NOMBRE") & vbTab & dr("P1") & vbTab & dr("P2") & vbTab & dr("P3"))
            Loop
            dr.Close()

            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 3, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 4, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 5, "Grand Total")

            Fg.AutoSizeCols()


            Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1

            Fg.Redraw = True
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmDeducOper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Deducciones operadores")
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        Try
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            CREA_TAB(FrmDeducOperAE, "Deduccion operador")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            Var2 = ""
            CREA_TAB(FrmDeducOperAE, "Deduccion operador")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        CADENA = ""
        DESPLEGAR()
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click

        CADENA = " AND FECHA = '" & FSQL(Date.Now) & "'"
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        CADENA = " AND FECHA = '" & FSQL(dt) & "'"
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        CADENA = " AND MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & ""
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        CADENA = " AND MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year
        DESPLEGAR()
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        CADENA = ""
        DESPLEGAR()
    End Sub
    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            CADENA = " AND (CAST(CVE_OPER AS VARCHAR) LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%') "
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            CREA_TAB(FrmDeducOperAE, "Deduccion operador")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

    End Sub
End Class
