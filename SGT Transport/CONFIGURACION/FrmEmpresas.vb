Imports System.Data.SqlClient
Public Class FrmEmpresas
    Private EmpresaNueva As Boolean
    Private SeModifico As Boolean

    Private Sub FrmEmpresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion_SAROCE() Then
            Me.Close()
            Return
        End If
        Try
            Application.EnableVisualStyles()
            SeModifico = False
            Panel1.Visible = False
            Panel1.Top = DataGridView1.Top
            Panel1.Left = DataGridView1.Left
            Panel1.Height = DataGridView1.Height
            Panel1.Width = DataGridView1.Width

            If Var2 = "Sin Border" Then
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Me.WindowState = FormWindowState.Maximized
            End If

            Desplegar()

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmEmpresas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Sub Desplegar()
        If Not Valida_Conexion_SAROCE() Then
            Return
        End If
        Try
            Dim SQLstr As String = "SELECT EMPRESA, NOMBRE, SERVIDOR, BASE, USUARIO, PASS, ISNULL(VISIBLE,1) AS VIS FROM EMPRESAS ORDER BY EMPRESA"
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAROCE
            cmd.CommandText = SQLstr
            dr = cmd.ExecuteReader()

            DataGridView1.Rows.Clear()

            While dr.Read()
                DataGridView1.Rows.Add(dr("EMPRESA"), "", dr("NOMBRE"), dr("SERVIDOR"), dr("BASE"), dr("USUARIO"), dr("PASS"), dr("VIS"))
            End While
            dr.Close()

            For i = 1 To 100
                cboEmpresa.Items.Add(Format(i, "00"))
            Next

            Panel1.Visible = False
        Catch ex As Exception
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("5. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TNombre_GotFocus(sender As Object, e As EventArgs)
        TNombre.Focus()
        TNombre.SelectAll()
        TNombre.BackColor = Color.Yellow
    End Sub

    Private Sub TNombre_LostFocus(sender As Object, e As EventArgs)
        TNombre.BackColor = Color.White
    End Sub

    Private Sub TServidor_GotFocus(sender As Object, e As EventArgs)
        tServidor.BackColor = Color.Yellow
        tServidor.SelectAll()
    End Sub

    Private Sub TServidor_LostFocus(sender As Object, e As EventArgs)
        tServidor.BackColor = Color.White
    End Sub

    Private Sub TBase_GotFocus(sender As Object, e As EventArgs)
        TBase.SelectAll()
        TBase.BackColor = Color.Yellow
    End Sub

    Private Sub TBase_LostFocus(sender As Object, e As EventArgs)
        TBase.BackColor = Color.White
    End Sub

    Private Sub TUsuario_GotFocus(sender As Object, e As EventArgs)
        TUsuario.SelectAll()
        TUsuario.BackColor = Color.Yellow
    End Sub

    Private Sub TUsuario_LostFocus(sender As Object, e As EventArgs)
        TUsuario.BackColor = Color.White
    End Sub

    Private Sub TPass_GotFocus(sender As Object, e As EventArgs)
        TPass.SelectAll()
        TPass.BackColor = Color.Yellow
    End Sub

    Private Sub TPass_LostFocus(sender As Object, e As EventArgs)
        TPass.BackColor = Color.White
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Dim LaEmpresa As String
        Dim i As Integer
        Dim r_ As Integer
        Try
            Panel1.Visible = True
            Me.Refresh()

            EmpresaNueva = False

            r_ = DataGridView1.CurrentCell.RowIndex
            LaEmpresa = DataGridView1.Rows(r_).Cells(0).Value.ToString

            For i = 0 To 99
                If cboEmpresa.Items(i) = LaEmpresa Then
                    cboEmpresa.SelectedIndex = i
                End If
            Next

            TUsuario.Visible = True
            TPass.Visible = True

            TNombre.Text = DataGridView1.Rows(r_).Cells(2).Value.ToString
            tServidor.Text = DataGridView1.Rows(r_).Cells(3).Value.ToString
            TBase.Text = DataGridView1.Rows(r_).Cells(4).Value.ToString
            TUsuario.Text = DataGridView1.Rows(r_).Cells(5).Value.ToString
            TPass.Text = DataGridView1.Rows(r_).Cells(6).Value.ToString
            ChVisible.Checked = DataGridView1.Rows(r_).Cells(7).Value
            BarraMenu.Enabled = False
            Me.TNombre.Focus()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub MnuEdit_Click(sender As Object, e As EventArgs) Handles MnuEdit.Click
        EmpresaNueva = False
        Call DataGridView1_DoubleClick(sender, e)
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        Try

            If cboEmpresa.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione una empresa")
                Exit Sub
            End If
            Dim NumEmpresa As String

            NumEmpresa = cboEmpresa.Items(cboEmpresa.SelectedIndex).ToString

            If Not OpenSAE(tServidor.Text, TBase.Text, TUsuario.Text, TPass.Text) Then
                MsgBox("Imposible conectarse a la base de datos " & TBase.Text, , "Conección SQL SERVER")
                Return
            End If
            cnSQL.Close()

            Dim cmd As New SqlCommand With {.Connection = cnSAROCE}

            SQL = "UPDATE EMPRESAS SET NOMBRE = '" & TNombre.Text & "',
                  SERVIDOR = '" & tServidor.Text & "',
                  BASE = '" & TBase.Text & "',
                  USUARIO = '" & TUsuario.Text & "',
                  PASS = '" & TPass.Text & "',
                  VISIBLE = 1
                  WHERE EMPRESA = '" & NumEmpresa & "'
                  IF @@ROWCOUNT = 0
                  INSERT INTO EMPRESAS (EMPRESA, NOMBRE, SERVIDOR, BASE, USUARIO, PASS, VISIBLE)
                  VALUES ('" & NumEmpresa & "','" & TNombre.Text & "','" & tServidor.Text & "','" &
                  TBase.Text & "','" & TUsuario.Text & "','" & TPass.Text & "',1)"
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()

            SeModifico = True

            Desplegar()

            MsgBox("Los datos se grabaron satisfactorimente")

            Panel1.Visible = False
            BarraMenu.Enabled = True

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuEliminar_Click(sender As Object, e As EventArgs) Handles MnuEliminar.Click
        Dim NumEmpresa As String
        Dim r_ As Integer

        Try
            r_ = DataGridView1.CurrentCell.RowIndex
            NumEmpresa = DataGridView1.Rows(r_).Cells(0).Value.ToString

            If MsgBox("Realmente desea eliminar la empresa " & NumEmpresa & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Desplegar()
                Exit Sub
            End If

            Dim cmd As New SqlCommand With {.Connection = cnSAROCE, .CommandText = "DELETE FROM EMPRESAS WHERE EMPRESA = '" & NumEmpresa & "'"}
            cmd.ExecuteNonQuery()

            Desplegar()

            MsgBox("El registro se elimino satisfactoriamente")

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuNuevo_Click(sender As Object, e As EventArgs) Handles MnuNuevo.Click
        Try
            EmpresaNueva = True
            Panel1.Visible = True
            BarraMenu.Enabled = False
            cboEmpresa.SelectedIndex = -1
            tServidor.Text = ""
            TNombre.Text = ""
            TBase.Text = ""
            TUsuario.Text = ""
            TPass.Text = ""
            ChVisible.Checked = True

            cboEmpresa.Focus()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CmdCancelar_Click(sender As Object, e As EventArgs) Handles CmdCancelar.Click
        Panel1.Visible = False
        BarraMenu.Enabled = True
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click

        Me.Close()
        Try
            If SeModifico Then
                Me.Hide()
                FrmSelEmpresa.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = 46 Then
            Call MnuEliminar_Click(sender, e)
        End If
    End Sub
    Private Sub FrmEmpresas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Empresas")
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Index = 6 Then
            If Not IsNothing(e.Value) Then
                e.Value = New String("*"c, e.Value.ToString().Length)
                e.FormattingApplied = True
            End If
        End If
    End Sub
End Class