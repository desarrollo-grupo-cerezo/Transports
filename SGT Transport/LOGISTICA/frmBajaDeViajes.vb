Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmBajaDeViajes
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmBajaDeViajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

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
            SQL = "SELECT TOP 200 B.CVE_BAJA, B.STATUS, B.CLIENTE, NOMBRE, B.FECHA, 
                (SELECT SUM(SUBTOTAL) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS STOTAL, 
                (SELECT SUM(IVA) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS IV, 
                (SELECT SUM(RETENCION) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS RET, 
                (SELECT SUM(NETO) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS NET 
                FROM GCBAJA_VIAJE B 
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = B.CLIENTE
                ORDER BY CVE_BAJA DESC"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Cliente"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Nombre"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Fecha"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Fg(0, 6) = "Sub-total"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            c6.Format = "###,###,##0.00"

            Fg(0, 7) = "IVA"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            c7.Format = "###,###,##0.00"

            Fg(0, 8) = "Retencion"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            c8.Format = "###,###,##0.00"

            Fg(0, 9) = "Neto"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            c9.Format = "###,###,##0.00"

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmBajaDeViajes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Baja de Viajes")
        Me.Dispose()
    End Sub

    Private Sub frmBajaDeViajes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barConsultBajas_Click(Nothing, Nothing)
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
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            'frmBajaDeViajesAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barConsultBajas_Click(sender As Object, e As EventArgs) Handles barConsultBajas.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Consulta"
                Var10 = Fg(Fg.Row, 1)
                Var9 = Fg(Fg.Row, 3)
                Var8 = Fg(Fg.Row, 4)
                Var11 = Fg(Fg.Row, 5)
                frmBajaViajeConsul.ShowDialog()
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEliminar_Click(sender As Object, e As EventArgs)
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCBAJA_VIAJE SET STATUS = 'B' WHERE CVE_BAJA = " & Fg(Fg.Row, 1)
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 120

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
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
