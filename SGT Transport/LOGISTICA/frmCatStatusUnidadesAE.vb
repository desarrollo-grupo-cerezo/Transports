Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmCatStatusUnidadesAE
    Private Sub frmCatStatusUnidadesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        barMenu.BackColor = Color.FromArgb(207, 221, 238)


        tDescr.MaxLength = 60
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        tClave.Text = ""
        tDescr.Text = ""

        If Var1 = "Nuevo" Then
            Try
                tClave.Text = GET_MAX("GCCAT_STATUS_UNIDADES", "CLAVE")
                tClave.Enabled = False
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

                SQL = "SELECT C.CLAVE, C.DESCR, ORDEN FROM GCCAT_STATUS_UNIDADES C WHERE  CLAVE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CLAVE").ToString
                    tDescr.Text = dr("DESCR").ToString
                    tORDEN.Text = dr.ReadNullAsEmptyInteger("ORDEN")
                End If
                dr.Close()

                tClave.Enabled = False
                tDescr.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmCatStatusUnidadesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmCatStatusUnidadesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCCAT_STATUS_UNIDADES SET DESCR = @DESCR, ORDEN = @ORDEN " &
            "WHERE CLAVE = @CLAVE " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCCAT_STATUS_UNIDADES (CLAVE, DESCR, STATUS, ORDEN, UUID) VALUES(@CLAVE, @DESCR, 'A', @ORDEN, NEWID())"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CLAVE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tClave.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@ORDEN", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tORDEN.Text)
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

    Private Sub frmCatStatusUnidadesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
