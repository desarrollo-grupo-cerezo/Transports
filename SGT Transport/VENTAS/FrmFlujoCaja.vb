Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class FrmFlujoCaja
    Private Sub FrmFlujoCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            Me.CenterToScreen()

            TIMPORTE.Value = 0
            'TCLAVE.Value = 0
            TOBS.Value = ""

            BtnCpto.FlatStyle = FlatStyle.Flat
            BtnCpto.FlatAppearance.BorderSize = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmFlujoCaja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarGrabar.Click
        Dim TIPO_MOV As String, CAJA As Integer, IMPORTE As Decimal, CONTINUA As Boolean = False

        Dim result = RJMessageBox.Show("Realmente desea grabar el flujo de caja?.",
                                       "Question Icon", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then

            Try
                If IsNothing(TCLAVE.Value) OrElse IsDBNull(TCLAVE.Value) Then
                    RJMessageBox.Show("Por favor capture el concepto", "Advertencia", MessageBoxButtons.OK)
                    Return
                Else
                    TCLAVE.UpdateValueWithCurrentText()
                End If

                If TCLAVE.Value <= 0 Then
                    RJMessageBox.Show("Por favor capture el concepto", "Advertencia", MessageBoxButtons.OK)
                    Return
                End If
            Catch ex As Exception
            End Try

            Try
                If IsNothing(TIMPORTE.Value) OrElse IsDBNull(TIMPORTE.Value) Then
                    RJMessageBox.Show("Por favor capture el importe", "Advertencia", MessageBoxButtons.OK)
                    Return
                Else
                    TIMPORTE.UpdateValueWithCurrentText()
                End If

                If TIMPORTE.Value <= 0 Then
                    RJMessageBox.Show("Por favor capture el importe", "Advertencia", MessageBoxButtons.OK)
                    Return
                End If

                IMPORTE = TIMPORTE.Value
            Catch ex As Exception
            End Try
            Try
                If IsNothing(TOBS.Value) OrElse IsDBNull(TOBS.Value) Then
                    TOBS.Value = ""
                Else
                    TOBS.UpdateValueWithCurrentText()
                End If
            Catch ex As Exception
            End Try

            Try
                If RadEntrada.Checked Then
                    TIPO_MOV = "E"
                Else
                    TIPO_MOV = "S"
                End If

                SQL = "INSERT INTO SOFLUJO (CLAVE, TIPO_MOV, CAJA, USUARIO, CLAVE_SAE, IMPORTE, OBSER)
                    OUTPUT Inserted.ID VALUES('" & TCLAVE.Value & "','" & TIPO_MOV & "','" & CAJA & "','" &
                    USER_GRUPOCE & "','" & CLAVESAE & "','" & IMPORTE & "','" & TOBS.Value & "')"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If IsNumeric(returnValue) Then
                            If Convert.ToInt64(returnValue) > 0 Then
                                MsgBox("El flujo de caja se grabo correctamente")
                                Me.Close()
                            End If
                        End If
                    End If
                End Using

            Catch ex As Exception
                BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCpto_Click(sender As Object, e As EventArgs) Handles BtnCpto.Click
        Try
            Var2 = "Flujo"
            If RadEntrada.Checked Then
                Var5 = "E"
            Else
                Var5 = "S"
            End If
            Var4 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLAVE.Value = Var4
                LtDescr.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TIMPORTE.Select()
            Else
                TCLAVE.Value = ""
            End If
        Catch ex As Exception
            Bitacora("79. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("79. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCpto_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLAVE_Validated(sender As Object, e As EventArgs) Handles TCLAVE.Validated
        Try
            If TCLAVE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If RadEntrada.Checked Then
                    Var5 = "E"
                Else
                    Var5 = "S"
                End If
                DESCR = BUSCA_CAT("Flujo", TCLAVE.Value)
                If DESCR = "" Then
                    MsgBox("Concepto inexistente")
                    TCLAVE.Value = ""
                Else
                    LtDescr.Text = DESCR
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RadEntrada_CheckedChanged(sender As Object, e As EventArgs) Handles RadEntrada.CheckedChanged
        If RadEntrada.Checked Then
            TCLAVE.Value = ""
            LtDescr.Text = ""
        End If
    End Sub

    Private Sub RadSalida_CheckedChanged(sender As Object, e As EventArgs) Handles RadSalida.CheckedChanged
        If RadSalida.Checked Then
            TCLAVE.Value = ""
            LtDescr.Text = ""
        End If
    End Sub
End Class