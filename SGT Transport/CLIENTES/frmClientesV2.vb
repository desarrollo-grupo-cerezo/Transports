Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.Threading.Tasks

Public Class FrmClientesV2
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmClientesV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(MNUEliminarCliente, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")
            Me.WindowState = FormWindowState.Maximized

            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg.Rows.Count = 1
            Fg.Cols.Count = 11

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            If Not pwPoder Then
                MNUClientesBaja.Visible = False
            End If
            DERECHOS()
            'DESPLEGAR_CLIE()
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmClientesV2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Saldos de clientes")
        Me.Dispose()
    End Sub
    Sub DERECHOS()
        Dim z As Integer = 0

        If pwPoder Then
            BarNuevo.Visible = True
            BarEdit.Visible = True
            MNUEliminarCliente.Visible = True
        Else
            Try
                BarNuevo.Visible = False
                BarEdit.Visible = False
                MNUEliminarCliente.Visible = False

                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 10100 AND CLAVE < 10500"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            z = z + 1
                            Select Case dr("CLAVE")
                                Case 10101
                                    BarNuevo.Visible = True
                                Case 10130
                                    BarEdit.Visible = True
                                Case 10160
                                    MNUEliminarCliente.Visible = True
                            End Select
                        End While
                    End Using
                End Using
                If z = 0 Then
                    BarNuevo.Visible = True
                    BarEdit.Visible = True
                    MNUEliminarCliente.Visible = True
                End If
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR(Optional FSTATUS As String = " WHERE STATUS = 'A'")
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Fg.Redraw = False

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT CLAVE, STATUS, NOMBRE, RFC, SALDO 
                FROM CLIE" & Empresa & FSTATUS
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            TITULOS()

            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            CREA_TAB(frmClientesAE, "Cliente")

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            CREA_TAB(frmClientesAE, "Cliente")

        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
    Private Sub MNUAltaCxC_Click(sender As Object, e As EventArgs) Handles MNUAltaCxC.Click
        frmRecepcionPagosCxC.ShowDialog()
    End Sub
    Private Sub MNUEstadoCuenta_Click(sender As Object, e As EventArgs) Handles MNUEstadoCuenta.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1)
                Var5 = Fg(Fg.Row, 3)
                Var49 = Fg(Fg.Row, 5)

                FrmEdoCuentaCliente.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MNUClientesBaja_Click(sender As Object, e As EventArgs) Handles MNUClientesBaja.Click
        Try
            If pwPoder Then
                DESPLEGAR(" WHERE STATUS = 'B'")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MNUEliminarCliente_Click(sender As Object, e As EventArgs) Handles MNUEliminarCliente.Click
        Try
            If MsgBox("Realmente desea de baja al cliente?", vbYesNo) = vbYes Then
                SQL = "UPDATE CLIE" & Empresa & " SET STATUS = 'B' WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"
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
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS()
        Try
            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "RFC"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Saldo"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Saldo al corriente"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Saldo a 30 dias"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Saldo a 60 dias"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 9) = "Saldo a 90 dias"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Saldo a mas de 90 dias"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmClientesV2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    MNUEliminarCliente_Click(Nothing, Nothing)
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

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "CLIENTES")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Async Function DESPLEGAR_CLIE(Optional FSTATUS As String = " WHERE STATUS = 'A'") As Task

        Try
            cnSAE.Close()

            Dim result As Integer = Await OpenSAEAsync(Empresa)

            SQL = "SELECT CLAVE, STATUS, NOMBRE, RFC, SALDO
                FROM CLIE" & Empresa & FSTATUS

            Dim query = cnSAE.CreateCommand()
            query.CommandText = SQL
            query.CommandType = CommandType.Text

            Using dr = Await query.ExecuteReaderAsync()

                While Await dr.ReadAsync()
                    Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("STATUS") & vbTab & dr("NOMBRE") & vbTab &
                               dr("RFC") & vbTab & dr("SALDO"))
                End While
            End Using
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Function

End Class
