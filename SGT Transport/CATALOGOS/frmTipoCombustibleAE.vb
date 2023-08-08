Imports System.Data.SqlClient
Public Class FrmTipoCombustibleAE
    Private Sub FrmTipoCombustibleAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub FrmTipoCombustibleAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub FrmTipoCombustibleAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Me.CenterToScreen()
        If Var1 = "Nuevo" Then
            Try
                TClave.Text = GET_MAX("GCTIPO_COMBUSTIBLE", "CVE_TIPO")
                TClave.Enabled = False
                TDescr.Text = ""
                TDescr.Select()

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

                SQL = "SELECT T.CVE_TIPO, T.STATUS, T.DESCR FROM GCTIPO_COMBUSTIBLE T WHERE CVE_TIPO = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TClave.Text = dr("CVE_TIPO")
                    TDescr.Text = dr("DESCR")
                Else
                    TClave.Text = ""
                    TDescr.Text = ""
                End If
                dr.Close()

                TClave.Enabled = False
                TDescr.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If TDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCTIPO_COMBUSTIBLE SET CVE_TIPO = @CVE_TIPO, DESCR = @DESCR" &
            " WHERE CVE_TIPO = @CVE_TIPO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCTIPO_COMBUSTIBLE (CVE_TIPO, STATUS, DESCR) VALUES(@CVE_TIPO, 'A', @DESCR)"

        cmd.CommandText = SQL



        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_TIPO", SqlDbType.SmallInt).Value = TClave.Text

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDescr.Text

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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()

    End Sub
End Class
