Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmContratos
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private CADENA As String

    Private Sub FrmContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        DERECHOS()

        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.KeyPreview = True

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            CADENA = ""

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                'barGrabar.Visible = False
                barNuevo.Visible = False
                barEdit.Visible = False
                barEliminar.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                    (CLAVE >= 11500 AND CLAVE < 11990)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 11501  '
                                    barNuevo.Visible = True
                                Case 11510  '
                                    barEdit.Visible = True
                                Case 11520  '
                                    barEliminar.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            SQL = "SELECT CAST(T.CVE_CON AS INT), ISNULL(C3.NOMBRE,'') AS NOMBRE_CONTRATO, ISNULL(C.NOMBRE,'') AS NOMBRE_ORIGEN, ISNULL(C2.NOMBRE,'') AS NOMBRE_DESTINO, " &
                "RE.DESCR AS RECEN, EE.DESCR AS ENTEN " &
                "FROM GCCONTRATO T " &
                "LEFT JOIN GCCONTRATOS_TAB_RUTAS B ON B.CVE_CON = T.CVE_CON " &
                "LEFT JOIN GCCLIE_OP C ON C.CLAVE = T.CLAVE_O " &
                "LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE = T.CLAVE_D " &
                "LEFT JOIN GCCLIE_OP C3 ON C3.CLAVE = T.NO_CONTRATO " &
                "LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = T.RECOGER_EN " &
                "LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = T.ENTREGAR_EN " &
                "WHERE " & CADENA & " T.STATUS = 'A' ORDER BY CAST(T.CVE_CON AS INT) DESC"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg(0, 1) = "No contrato"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Long)

            Fg(0, 2) = "Nombre contrato"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre origen"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Nombre destino"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Recoger en"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Entregar en"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmContratos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Contratos")
        Me.Dispose()
    End Sub

    Private Sub FrmContratos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    BarEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    MnuSalir_Click(Nothing, Nothing)
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

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            'frmContratosAE.ShowDialog()
            CREA_TAB(frmContratosAE, "Contratos AE")
            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            'frmContratosAE.ShowDialog()
            CREA_TAB(frmContratosAE, "Contratos AE")
            'DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                    Var4 = ""
                    'FrmMotivoBaja.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        'Dim CVE_MTC As Long = 0
                        Try
                            'CVE_MTC = GRABA_MOTIVO_CANC("CONTRATOS", Var4)
                        Catch ex As Exception
                            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                        'SQL = "UPDATE GCCONTRATO SET STATUS = 'B', CVE_MTC = " & CVE_MTC & " WHERE CVE_CON = '" & Fg(Fg.Row, 1) & "'"
                    Else
                        'Dim ResultMensaje As String
                        'ResultMensaje = MensajeBox("Cancelación abortada ¡¡¡¡¡", "Proceso finalizado", "Error")
                    End If

                    SQL = "UPDATE GCCONTRATO SET STATUS = 'B' WHERE CVE_CON = '" & Fg(Fg.Row, 1) & "'"

                    Dim cmd As New SqlCommand
                    cmd.Connection = cnSAE
                    cmd.CommandTimeout = 120

                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            MsgBox("El contrato se cancelo correctamente")
                            DESPLEGAR()
                        Else
                            MsgBox("NO se logro eliminar el registro")
                        End If
                    Else
                        MsgBox("!!NO se logro eliminar el registro!!")
                    End If


                End If
            Else
                MsgBox("Por favor seleccione un contrato")
            End If

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            CADENA = "(CAST(T.CVE_CON AS VARCHAR) LIKE '%" & tBox.Text & "%' OR C3.NOMBRE LIKE '%" & tBox.Text & "%' OR C2.NOMBRE LIKE '%" & tBox.Text & "%' OR C.NOMBRE LIKE '%" & tBox.Text & "%' OR " &
                "RE.DESCR LIKE '%" & tBox.Text & "%' OR EE.DESCR LIKE '%" & tBox.Text & "%') AND "
            DESPLEGAR()
            Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        CADENA = ""

        DESPLEGAR()
    End Sub
End Class
