Imports System.Data.SqlClient
Public Class FrmPreciosGCAE
    Private Sub FrmPreciosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        tDESCRIPCION.MaxLength = 25

        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then
            Try

                tCVE_PRECIO.Text = GET_MAX("GCPRECIOS", "CVE_PRECIO")
                tCVE_PRECIO.Enabled = False
                tDESCRIPCION.Text = ""
                tDESCRIPCION.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.CVE_PRECIO, P.DESCRIPCION, P.STATUS FROM GCPRECIOS P WHERE CVE_PRECIO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_PRECIO.Text = dr("CVE_PRECIO").ToString
                    tDESCRIPCION.Text = dr("DESCRIPCION").ToString
                Else
                    tCVE_PRECIO.Text = 1
                    tDESCRIPCION.Text = ""
                End If
                dr.Close()

                tCVE_PRECIO.Enabled = False
                tDESCRIPCION.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmPreciosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmPreciosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        If tDESCRIPCION.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCPRECIOS SET DESCRIPCION = @DESCRIPCION" &
            " WHERE CVE_PRECIO = @CVE_PRECIO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCPRECIOS (CVE_PRECIO, DESCRIPCION, STATUS) VALUES(@CVE_PRECIO, @DESCRIPCION, 'A')"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_PRECIO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PRECIO.Text)
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = tDESCRIPCION.Text
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

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
