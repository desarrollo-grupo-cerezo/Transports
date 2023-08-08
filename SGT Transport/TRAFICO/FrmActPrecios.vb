Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class FrmActPrecios
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private NRow As Long = 0
    Private CADENA As String = ""

    Private Sub FrmActPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Me.WindowState = FormWindowState.Maximized
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - C1ToolBar1.Height - 50
        Fg.DrawMode = DrawModeEnum.OwnerDraw


        DESPLEGAR()
    End Sub

    Sub DESPLEGAR()
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ds As New DataSet

            Fg.Redraw = False
            '6 PRECIO
            '10 CVE_ESQIMPU  
            '11 DESCRIPESQ
            SQL = "SELECT L.CAMPLIB10 AS 'Cliente', I.CVE_ART AS 'Articulo', I.DESCR AS 'Descripcion', L.CAMPLIB7 AS 'Origen', L.CAMPLIB8 AS 'Destino',
                P.PRECIO AS 'Precio', (T.IMPUESTO3 * P.PRECIO/100) as 'Ret 4%', (T.IMPUESTO4 * P.PRECIO/100) AS 'IVA', 
                (P.PRECIO + (T.IMPUESTO3 * P.PRECIO/100) + (T.IMPUESTO4 * P.PRECIO/100) ) AS 'Total', I.CVE_ESQIMPU, T.DESCRIPESQ
                FROM  INVE" & Empresa & " I
                INNER JOIN INVE_CLIB" & Empresa & " L ON I.CVE_ART = L.CVE_PROD
                INNER JOIN IMPU" & Empresa & " T ON I.CVE_ESQIMPU = T.CVE_ESQIMPU
                INNER JOIN PRECIO_X_PROD" & Empresa & " P ON I.CVE_ART = P.CVE_ART
                WHERE P.CVE_PRECIO = 1 AND I.LIN_PROD = 'SV' AND L.CAMPLIB10 <> ''" & CADENA

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg.Cols(0).Width = 40
            If NRow > 0 Then
                Fg.Row = NRow
                NRow = 0
            End If

            Fg.Cols(6).Format = "###,###,##0.00"
            Fg.Cols(6).Format = "###,###,##0.00"
            Fg.Cols(7).Format = "###,###,##0.00"
            Fg.Cols(8).Format = "###,###,##0.00"
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg.AutoSizeCols()
            Fg.Cols(10).Width = 0
            Fg.Cols(11).Width = 0


            Fg.Redraw = True
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmActPrecios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Actualización de precios")
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        Try
            '6 PRECIO
            '10 CVE_ESQIMPU  
            '11 DESCRIPESQ
            NRow = Fg.Row
            Var2 = Fg(Fg.Row, 6)
            Var3 = Fg(Fg.Row, 10)
            Var4 = Fg(Fg.Row, 11)

            FRmTraficUpdatePrecio.LtArt.Text = Fg(Fg.Row, 2)
            FRmTraficUpdatePrecio.LtDescr.Text = Fg(Fg.Row, 3)

            FRmTraficUpdatePrecio.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarActualizar_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        If e.KeyCode = Keys.F3 Then
            BarActualizar_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 27 Then
            tBox.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            tBox.Focus()
        End If
    End Sub

    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try

            CADENA = " AND (UPPER(I.CVE_ART) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(I.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR
                           UPPER(L.CAMPLIB10) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(L.CAMPLIB7) LIKE '%" & tBox.Text.ToUpper & "%' OR
                           UPPER(L.CAMPLIB8) LIKE '%" & tBox.Text.ToUpper & "%' OR P.PRECIO LIKE '%" & tBox.Text.ToUpper & "%')"
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tBox_KeyDown(sender As Object, e As KeyEventArgs) Handles tBox.KeyDown
        If e.KeyCode = Keys.Down Then
            Fg.Focus()
        End If
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub BarRefrescar_Click(sender As Object, e As ClickEventArgs) Handles BarRefrescar.Click
        CADENA = ""
        DESPLEGAR()

    End Sub
End Class
