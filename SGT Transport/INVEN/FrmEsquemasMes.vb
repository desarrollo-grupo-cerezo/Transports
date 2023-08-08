Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmEsquemasMes
    Private NRow As Integer = 0

    Private Sub FrmEsquemasMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Try
            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 6

            Fg.Dock = DockStyle.Fill

            Fg.Rows(0).Height = 40

            Fg(0, 1) = "Impuesto"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)
            c1.Visible = False

            Fg(0, 2) = "Mes"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Int32)
            c2.Visible = False

            Fg(0, 3) = "Mes"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Impuesto"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Cuenta"
            Dim c5 As Column = Fg.Cols(4)
            c5.DataType = GetType(String)

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

            SQL = "SET LANGUAGE Spanish
                   SELECT NUM_IMPU, MES, MES_NOMBRE = UPPER(DATENAME (MONTH, CONCAT('1900', RIGHT(CONCAT('0', MES), 2) ,'01'))), IMPUESTO = CASE NUM_IMPU WHEN 3 THEN 'RET. IVA' WHEN 4 THEN 'IVA' END, CUENTA FROM CTAMES ORDER BY MES, NUM_IMPU"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("NUM_IMPU") & vbTab & dr("MES") & vbTab & dr("MES_NOMBRE") & vbTab & dr("IMPUESTO") & vbTab & dr("CUENTA"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

            If NRow > 0 Then
                Fg.Row = NRow
            End If
            NRow = 0
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmEsquemas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Impuestos/Cuentas por mes")
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            Var3 = Fg(Fg.Row, 2)
            Var4 = "Mes"
            NRow = Fg.Row

            FrmEsquemasYearMesAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class