Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmSelItemBinding
    Private Proceso As String
    Private CADENA As String

    Private BindingSource1 As New BindingSource
    Private Sub FrmSelItemBinding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not Valida_Conexion() Then
                Return
            End If
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            Me.CenterToScreen()
            Fg.Dock = DockStyle.Fill

            Proceso = Prosec
            'BindingSource1.ResetBindings(True)
            'BindingSource1.RemoveFilter()

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True
            Fg.Rows.Count = 1
            CADENA = ""
            Select Case Proceso
                Case "CP"
                    'Var7 = TPOBLACION_SAT.Text
                    'Var8 = TMUNICIPIO_SAT.Text
                    'Var9 = TESTADO_SAT.Text
                    If Var7.Trim.Length > 0 Then CADENA += "localidad = '" & Var7 & "' AND "
                    If Var8.Trim.Length > 0 Then CADENA += "municipio = '" & Var8 & "' AND "
                    If Var9.Trim.Length > 0 Then CADENA += "estado = '" & Var9 & "' AND "

                    If CADENA.Length > 0 And Var6.Trim.Length = 0 Then
                        CADENA = CADENA.Substring(0, CADENA.Length - 5)
                    Else
                        If Var6.Trim.Length > 0 Then
                            CADENA = " codigoPostal = '" & Var6 & "'"
                        End If
                    End If
                    SQL = "SELECT codigoPostal, estado, municipio, localidad FROM tblccodigopostal ORDER BY codigoPostal"
                Case "COLONIAS"
                    'Var6 = TCOLONIA_SAT.Text
                    'Var7 = TCP_SAT.Text
                    If Var6.Trim.Length > 0 And Var7.Trim.Length > 0 Then
                        CADENA = " colonia = '" & Var6 & "' AND codigopostal = '" & Var7 & "'"
                    Else
                        If Var6.Trim.Length > 0 Then
                            CADENA = " colonia = '" & Var6 & "'"
                        ElseIf Var7.Trim.Length > 0 Then
                            CADENA = " codigopostal = '" & Var7 & "'"
                        Else
                            CADENA = ""
                        End If
                    End If


                    SQL = "SELECT colonia, codigopostal, nombreasentamiento FROM tblcolonias ORDER BY codigopostal"
            End Select

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            If CADENA.Trim.Length > 0 Then
                BindingSource1.Filter = CADENA
            End If

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            If Fg.Rows.Count = 1 Then

                BindingSource1.RemoveFilter()

                Select Case Proceso
                    Case "CP"
                        SQL = "SELECT codigoPostal, estado, municipio, localidad FROM tblccodigopostal ORDER BY codigoPostal"
                    Case "COLONIAS"
                        SQL = "SELECT colonia, codigopostal, nombreasentamiento FROM tblcolonias ORDER BY codigopostal"
                End Select
                da = New SqlDataAdapter(SQL, cnSAE)
                dt = New DataTable ' crear un DataTable
                da.SelectCommand.CommandTimeout = 120
                da.Fill(dt)

                BindingSource1.DataSource = dt
                Fg.DataSource = BindingSource1.DataSource

                If Fg.Rows.Count = 1 Then

                End If
            End If

            Select Case Proceso
                Case "CP"
                    SQL = "SELECT codigoPostal, estado, municipio, localidad FROM tblccodigopostal ORDER BY codigoPostal"
                    Fg.Cols.Count = 5
                    Fg(0, 1) = "Código postal"
                    Fg(0, 2) = "Estado"
                    Fg(0, 3) = "Municipio"
                    Fg(0, 4) = "Localidad"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 80
                    Fg.Cols(2).Width = 70
                    Fg.Cols(3).Width = 70
                    Fg.Cols(4).Width = 70
                    Me.Width = 480
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False

                Case "COLONIAS"
                    CADENA = ""
                    'SQL = "SELECT colonia, codigopostal, nombreasentamiento FROM tblcolonias " & CADENA & " ORDER BY codigopostal"
                    Fg.Cols.Count = 4
                    Fg(0, 1) = "Colonia"
                    Fg(0, 2) = "Código postal"
                    Fg(0, 3) = "Nombre asentamiento"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 80
                    Fg.Cols(2).Width = 80
                    Fg.Cols(3).Width = 120
                    Me.Width = 480
                    'Me.Height = 200
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False

            End Select

            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmSelItemBinding_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles TBox.TextChanged
        Try
            SQL = ""
            Select Case Proceso
                Case "CP"
                    SQL = "codigoPostal LIKE '%" & TBox.Text & "%' OR estado LIKE '%" & TBox.Text & "%' OR 
                        municipio LIKE '%" & TBox.Text & "%' OR localidad LIKE '%" & TBox.Text & "%'"
                Case "COLONIAS"
                    SQL = "colonia LIKE '%" & TBox.Text & "%' OR codigopostal LIKE '%" & TBox.Text & "%' OR 
                        nombreasentamiento LIKE '%" & TBox.Text & "%' "
            End Select
            If SQL.Trim.Length > 0 Then
                BindingSource1.RemoveFilter()
                If TBox.Text.Trim.Length > 0 Then
                    BindingSource1.Filter = SQL
                Else
                    BindingSource1.Filter = ""
                End If

                Fg.DataSource = BindingSource1.DataSource

                Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
            End If
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TBox.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TBox_TextChanged(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub

    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "*" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Try
                BarAceptar_Click(Nothing, Nothing)
            Catch ex As Exception
                Bitacora(ex.Message & vbNewLine & ex.StackTrace & "Proceso: " & Proceso)
                MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & "Proceso: " & Proceso)
            End Try
        End If
    End Sub
    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs) Handles Fg.KeyUp
        If e.KeyCode = Keys.Left Then
            TBox.Focus()
        End If
    End Sub
    Private Sub BarAceptar_Click(sender As Object, e As ClickEventArgs) Handles BarAceptar.Click
        Select Case Proceso
            Case "CP"
                If Fg.Row > 0 Then
                    Var4 = Fg(Fg.Row, 1) 'CP
                    Var7 = Fg(Fg.Row, 2) 'ESTADO
                    Var8 = Fg(Fg.Row, 3) 'MUNICIPIO
                    Var9 = Fg(Fg.Row, 4) 'LOCALIDAD
                End If
            Case "COLONIAS"
                If Fg.Row > 0 Then
                    Var4 = Fg(Fg.Row, 1) '"Colonia"
                    Var7 = Fg(Fg.Row, 2) '"Código postal"
                    Var8 = Fg(Fg.Row, 3) '"Nombre asentamiento"
                    'Fg(0, 1) = "Colonia"
                    'Fg(0, 2) = "Código postal"
                    'Fg(0, 3) = "Nombre asentamiento"

                End If
        End Select
        Me.Close()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        BarAceptar_Click(Nothing, Nothing)
    End Sub
End Class