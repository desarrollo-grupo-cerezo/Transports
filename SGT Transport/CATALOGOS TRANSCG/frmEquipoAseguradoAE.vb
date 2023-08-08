Imports System.Data.SqlClient
Public Class frmEquipoAseguradoAE
    Private Sub frmEquipoAseguradoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        tCVE_ASE.Text = 0
        tDescr.Text = ""
        tActivo.Text = ""

        If Var1 = "Nuevo" Then
            Try
                tCVE_ASE.Text = GET_MAX("GCEQUIPO_ASEGURADO", "CVE_ASE")
                tCVE_ASE.Enabled = False
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

                SQL = "SELECT E.CVE_ASE, E.STATUS, E.DESCR, E.ACTIVO FROM GCEQUIPO_ASEGURADO E WHERE CVE_ASE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_ASE.Text = dr("CVE_ASE").ToString
                    tDescr.Text = dr("DESCR").ToString
                    tActivo.Text = dr("ACTIVO").ToString
                End If
                dr.Close()

                tCVE_ASE.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmEquipoAseguradoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmEquipoAseguradoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCEQUIPO_ASEGURADO SET DESCR = @DESCR, ACTIVO = @ACTIVO " &
            "WHERE CVE_ASE = @CVE_ASE " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCEQUIPO_ASEGURADO (CVE_ASE, STATUS, DESCR, ACTIVO, GUID) VALUES(@CVE_ASE, 'A', @DESCR, @ACTIVO, NEWID())"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_ASE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_ASE.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@ACTIVO", SqlDbType.VarChar).Value = tActivo.Text
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
End Class
