Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmPlazas
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmPlazas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.KeyPreview = True

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            SQL = "SELECT P.CLAVE as 'Clave',  P.STATUS as 'Estatus',  P.CIUDAD as 'Localidad',  P.MUNICIPIO as 'Municipio', 
                E.NOMBRE AS 'Estado', E.CLAVE_SAT_EST AS 'Clave SAT estado', E.PAIS AS 'Pais', E.CLAVE_SAT_PAIS AS 'Clave SAT pais', 
                P.CUEN_CONT AS 'Cuenta contable' 
                FROM GCPLAZAS P
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P.CVE_ESTADO
                WHERE P.STATUS = 'A' ORDER BY P.CLAVE"

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
        Fg.Redraw = False
        Try

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource


            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub

    Private Sub frmPlazas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Plazas")
        Me.Dispose()
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmPlazasAE.ShowDialog()

            SQL = "SELECT P.CLAVE as 'Clave',  P.STATUS as 'Estatus',  P.CIUDAD as 'Localidad',  P.MUNICIPIO as 'Municipio', 
                E.NOMBRE AS 'Estado', E.CLAVE_SAT_EST AS 'Clave SAT estado', E.PAIS AS 'Pais', E.CLAVE_SAT_PAIS AS 'Clave SAT pais', 
                P.CUEN_CONT AS 'Cuenta contable' 
                FROM GCPLAZAS P
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P.CVE_ESTADO
                WHERE P.STATUS = 'A' ORDER BY P.CLAVE"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmPlazasAE.ShowDialog()

            SQL = "SELECT P.CLAVE as 'Clave',  P.STATUS as 'Estatus',  P.CIUDAD as 'Localidad',  P.MUNICIPIO as 'Municipio', 
                E.NOMBRE AS 'Estado', E.CLAVE_SAT_EST AS 'Clave SAT estado', E.PAIS AS 'Pais', E.CLAVE_SAT_PAIS AS 'Clave SAT pais', 
                P.CUEN_CONT AS 'Cuenta contable' 
                FROM GCPLAZAS P
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P.CVE_ESTADO
                WHERE P.STATUS = 'A' ORDER BY P.CLAVE"

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                    SQL = "UPDATE GCPLAZAS SET STATUS = 'B' WHERE CLAVE = " & Fg(Fg.Row, 1)
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            MsgBox("El registro se elimino satisfactoriamente")

                            SQL = "SELECT P.CLAVE as 'Clave',  P.STATUS as 'Estatus',  P.CIUDAD as 'Localidad',  P.MUNICIPIO as 'Municipio', 
                                E.NOMBRE AS 'Estado', E.CLAVE_SAT_EST AS 'Clave SAT estado', E.PAIS AS 'Pais', E.CLAVE_SAT_PAIS AS 'Clave SAT pais', 
                                P.CUEN_CONT AS 'Cuenta contable' 
                                FROM GCPLAZAS P
                                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P.CVE_ESTADO
                                WHERE P.STATUS = 'A' ORDER BY P.CLAVE"

                            DESPLEGAR()
                        Else
                            MsgBox("NO se logro eliminar el registro")
                        End If
                    Else
                        MsgBox("!!NO se logro eliminar el registro!!")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub frmPlazas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTodos_Click(sender As Object, e As EventArgs) Handles BarTodos.Click
        SQL = "SELECT P.CLAVE as 'Clave',  P.STATUS as 'Estatus',  P.CIUDAD as 'Localidad',  P.MUNICIPIO as 'Municipio', 
                E.NOMBRE AS 'Estado', E.CLAVE_SAT_EST AS 'Clave SAT estado', E.PAIS AS 'Pais', E.CLAVE_SAT_PAIS AS 'Clave SAT pais', 
                P.CUEN_CONT AS 'Cuenta contable' 
                FROM GCPLAZAS P
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P.CVE_ESTADO
                ORDER BY P.CLAVE"

        DESPLEGAR()
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click

        SQL = "SELECT P.CLAVE as 'Clave',  P.STATUS as 'Estatus',  P.CIUDAD as 'Localidad',  P.MUNICIPIO as 'Municipio', 
                E.NOMBRE AS 'Estado', E.CLAVE_SAT_EST AS 'Clave SAT estado', E.PAIS AS 'Pais', E.CLAVE_SAT_PAIS AS 'Clave SAT pais', 
                P.CUEN_CONT AS 'Cuenta contable' 
                FROM GCPLAZAS P
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P.CVE_ESTADO
                WHERE P.STATUS = 'A' ORDER BY P.CLAVE"
        DESPLEGAR()

    End Sub
End Class
