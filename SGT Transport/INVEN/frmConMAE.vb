Imports System.Data.SqlClient
Public Class frmConMAE
    Private Sub frmConMAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()

        Me.KeyPreview = True
        Try
            cboCPN.Items.Clear()
            cboCPN.Items.Add("Cliente")
            cboCPN.Items.Add("Proveedor")
            cboCPN.Items.Add("Ninguno")
        Catch ex As Exception
        End Try
        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then

            Try


                'tCVE_CPTO.Text = GET_MAX("CONM" & Empresa, "CVE_CPTO", " WHERE TIPO_MOV = 'E'")
                GroupBox1.Enabled = True
                tCVE_CPTO.Enabled = False
                tDescr.Text = ""
                tDescr.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT N.CVE_CPTO, N.DESCR, N.CPN, N.CUEN_CONT, N.TIPO_MOV, N.STATUS, N.SIGNO " &
                    "FROM CONM" & Empresa & " N WHERE CVE_CPTO = " & Var2 & " AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_CPTO.Text = dr("CVE_CPTO").ToString
                    tDescr.Text = dr("DESCR").ToString
                    Select Case dr("CPN").ToString
                        Case "C"
                            cboCPN.SelectedIndex = 0
                        Case "P"
                            cboCPN.SelectedIndex = 1
                        Case Else
                            cboCPN.SelectedIndex = 2
                    End Select

                    tCUEN_CONT.Text = dr("CUEN_CONT").ToString
                    If dr("TIPO_MOV").ToString = "E" Then
                        radEntrada.Checked = True
                    Else
                        radSalida.Checked = False
                    End If

                    GroupBox1.Enabled = False
                Else
                    tCVE_CPTO.Text = ""
                    tDescr.Text = ""
                    cboCPN.SelectedIndex = 0
                    tCUEN_CONT.Text = ""
                    radEntrada.Checked = True

                    GroupBox1.Enabled = True
                End If
                dr.Close()

                tCVE_CPTO.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmConMAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmConMAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        If cboCPN.SelectedIndex = -1 Then
            cboCPN.SelectedIndex = 2
        End If


        SQL = "UPDATE CONM" & Empresa & " SET CVE_CPTO = @CVE_CPTO, DESCR = @DESCR, CPN = @CPN, CUEN_CONT = @CUEN_CONT, " &
            "TIPO_MOV = @TIPO_MOV, SIGNO = @SIGNO " &
            "WHERE CVE_CPTO = @CVE_CPTO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO CONM" & Empresa & " (CVE_CPTO, DESCR, CPN, CUEN_CONT, TIPO_MOV, STATUS, SIGNO) " &
            "VALUES(@CVE_CPTO, @DESCR, @CPN, @CUEN_CONT, @TIPO_MOV, 'A', @SIGNO)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_CPTO.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CPN", SqlDbType.VarChar).Value = cboCPN.Text.Substring(0, 1)
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
            cmd.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = IIf(radEntrada.Checked, "E", "S")

            cmd.Parameters.Add("@SIGNO", SqlDbType.SmallInt).Value = IIf(radEntrada.Checked, "1", "-1")

            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub frmConMAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub radEntrada_CheckedChanged(sender As Object, e As EventArgs) Handles radEntrada.CheckedChanged
        If radEntrada.Checked Then
            tCVE_CPTO.Text = GET_MAX("CONM" & Empresa, "CVE_CPTO", 0, " WHERE TIPO_MOV = 'E'")
        End If
    End Sub
    Private Sub radSalida_CheckedChanged(sender As Object, e As EventArgs) Handles radSalida.CheckedChanged
        If radSalida.Checked Then
            tCVE_CPTO.Text = GET_MAX("CONM" & Empresa, "CVE_CPTO", 0, " WHERE TIPO_MOV = 'S'")
        End If
    End Sub
End Class
