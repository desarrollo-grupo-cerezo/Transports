Imports System.Data.SqlClient

Public Class FrmSelFactura
    Private Sub FrmSelFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

    End Sub

    Private Sub FrmSelFactura_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub TACEPTAR_Click(sender As Object, e As EventArgs) Handles TACEPTAR.Click
        Dim ExistFac As Boolean = False
        Try
            If TCVE_DOC.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un viaje")
                Return
            Else
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT FACTURA FROM CFDI WHERE FACTURA = '" & TCVE_DOC.Text & "' AND ISNULL(ESTATUS,'') <> 'C'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                ExistFac = True
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

                If ExistFac Then
                    Var24 = TCVE_DOC.Text
                    Me.Close()
                Else
                    MsgBox("Factura inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCANCELAR_Click(sender As Object, e As EventArgs) Handles TCANCELAR.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            Var2 = "FACTURA CFDI"
            Var4 = "" : Var5 = "" : Var6 = "" : Var10 = ""

            FrmSelItem2.ShowDialog()

            MainRibbonForm.Activate()

            If Var4.Trim.Length > 0 Then
                TCVE_DOC.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub TCVE_DOC_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_DOC.KeyDown
        Try
            If e.KeyCode = 13 Then
                TACEPTAR_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class