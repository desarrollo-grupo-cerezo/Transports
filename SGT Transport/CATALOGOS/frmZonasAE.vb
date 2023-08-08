Imports System.Data.SqlClient

Public Class frmZonasAE
    Private CVE_ZONA As String
    Private TNODO As String


    Private Sub frmZonasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub frmZonasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub frmZonasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        CVE_ZONA = Var2
        TNODO = Var4
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var1 = "Nuevo" Then

            Try
                CVE_ZONA = GET_MAX("ZONA" & Empresa, "CVE_ZONA",6)
                tNOMBRE.Text = ""
                tCUENTA_CONTABLE.Text = ""
                tNOMBRE.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT N.CVE_ZONA, N.CVE_PADRE, N.TEXTO, N.TNODO, N.CTA_CONT, N.IMPUEFLETE, N.MONTOFLETE, N.FORMULA, N.STATUS " &
                    "FROM ZONA" & Empresa & " N WHERE CVE_ZONA = '" & CVE_ZONA & "' AND TNODO = '" & TNODO & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tNOMBRE.Text = dr("TEXTO")
                    tCUENTA_CONTABLE.Text = dr("CTA_CONT")
                    tMONTOFLETE.Value = dr("MONTOFLETE")
                Else
                    tNOMBRE.Text = ""
                    tCUENTA_CONTABLE.Text = ""
                    tMONTOFLETE.Value = 0
                End If
                dr.Close()
                tNOMBRE.Select()
            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE ZONA" & Empresa & " SET TEXTO = @TEXTO, CTA_CONT = @CTA_CONT, MONTOFLETE = @MONTOFLETE " &
            "WHERE CVE_ZONA = @CVE_ZONA " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO ZONA" & Empresa & " (CVE_ZONA, TEXTO, CTA_CONT, MONTOFLETE, STATUS) " &
            "VALUES (@CVE_ZONA, @TEXTO, @CTA_CONT, @MONTOFLETE, 'A')"

        cmd.commandtext = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = CVE_ZONA
            cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar).Value = tNOMBRE.Text
            cmd.Parameters.Add("@CTA_CONT", SqlDbType.VarChar).Value = tCUENTA_CONTABLE.Text
            cmd.Parameters.Add("@MONTOFLETE", SqlDbType.Float).Value = tMONTOFLETE.Text
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
            msgbox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub
End Class
