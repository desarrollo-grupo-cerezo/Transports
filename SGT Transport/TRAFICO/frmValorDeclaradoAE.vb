Imports System.Data.SqlClient
Public Class frmValorDeclaradoAE
    Private Sub frmValorDeclaradoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        Try
            tClave.Text = ""
            tDESCR.Text = ""
            tIMPORTE.Value = 0
            tDESCR.MaxLength = 120
        Catch ex As Exception

        End Try
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tClave.Text = GET_MAX("GCVALOR_DECLARADO", "CLAVE")
                tClave.Enabled = False
                tDESCR.Text = ""
                tDESCR.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT V.CLAVE, V.STATUS, V.DESCR, V.IMPORTE FROM GCVALOR_DECLARADO V WHERE CLAVE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CLAVE").ToString
                    tDESCR.Text = dr("DESCR").ToString
                    tIMPORTE.Value = dr("IMPORTE").ToString
                End If
                dr.Close()

                tClave.Enabled = False
                tDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmValorDeclaradoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmValorDeclaradoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCVALOR_DECLARADO SET DESCR = @DESCR, IMPORTE = @IMPORTE " &
            "WHERE CLAVE = @CLAVE " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCVALOR_DECLARADO (CLAVE, STATUS, DESCR, IMPORTE, GUID)" &
            " VALUES(@CLAVE, 'A', @DESCR, @IMPORTE, NEWID())"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CLAVE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tClave.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDESCR.Text
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tIMPORTE.Text)
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

    Private Sub tIMPORTE_KeyDown(sender As Object, e As KeyEventArgs) Handles tIMPORTE.KeyDown
        If e.KeyCode = 13 Then
            tDESCR.Select()

        End If
    End Sub
End Class