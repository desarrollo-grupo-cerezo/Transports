Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command

Public Class FrmMotivosCancel
    Private CADENA As String
    Private BindingSource2 As BindingSource = New BindingSource
    Private Sub FrmMotivosCancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            SplitM.BorderWidth = 0
            SplitM.Dock = DockStyle.Fill
            Split1.BorderWidth = 1
            Split2.BorderWidth = 1

            Fg.Dock = DockStyle.Fill
        Catch ex As Exception
        End Try

        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 40

            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-15)
            CADENA = " WHERE FECHAELAB BETWEEN '" & FSQL(dt) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59'"

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
            Fg.Redraw = False

            SQL = "SELECT CVE_MTC AS 'Clave', MODULO AS 'Modulo', DESCR AS 'Motivo cancelación', FECHAELAB AS 'Fecha', B.USUARIO AS 'Usuario', 
                U.NOMBRE AS 'Nombre usuario'
                FROM GCMOTIVO_CANC B 
                LEFT JOIN GCUSUARIOS U ON U.USUARIO = B.USUARIO " &
                CADENA &
                " ORDER BY FECHAELAB DESC"
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource2.DataSource = dt
            Fg.DataSource = BindingSource2.DataSource

            Dim cc1 As Column = Fg.Cols(4)
            cc1.DataType = GetType(DateTime)
            cc1.Format = "g"

            Fg.Cols(1).Width = 70 : Fg.Cols(2).Width = 150 : Fg.Cols(3).Width = 700 : Fg.Cols(4).Width = 130 : Fg.Cols(5).Width = 90 : Fg.Cols(6).Width = 160
            'Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub FrmMotivosCancel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Motivos cancelaciones")
        Me.Dispose()
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        CADENA = " WHERE FECHAELAB BETWEEN '" & FSQL(F1.Value) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59'"

        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "MOTIVOS CANCELACIONES")

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-15)
            CADENA = " WHERE FECHAELAB BETWEEN '" & FSQL(dt) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59'"

            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            CADENA = " WHERE FECHAELAB BETWEEN '" & FSQL(Date.Now) & " 00:00:00' AND '" & FSQL(Date.Now) & " 23:59:59'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)
            CADENA = " WHERE FECHAELAB BETWEEN '" & FSQL(dt) & " 00:00:00' AND '" & FSQL(dt) & " 23:59:59'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today

            CADENA = " WHERE MONTH(FECHAELAB) = " & dt.Month & " AND YEAR(FECHAELAB) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddMonths(-1)

            CADENA = " WHERE MONTH(FECHAELAB) = " & dt.Month & " AND YEAR(FECHAELAB) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            CADENA = ""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
