Imports System.Data.SqlClient

Public Class frmMecanicosAE
    Private Sub frmMecanicosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")

        Me.CenterToScreen()


        Me.KeyPreview = True
        Try
            tCVE_MEC.Text = ""
            tDescr.Text = ""
            If Var3 = "B" Then
                LtBaja.Visible = True
                BtnActivo.Visible = True
            Else
                LtBaja.Visible = False
                BtnActivo.Visible = False
            End If
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try

                tCVE_MEC.Text = GET_MAX("GCMECANICOS", "CVE_MEC")
                tCVE_MEC.Enabled = False
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

                SQL = "SELECT M.CVE_MEC, M.STATUS, M.DESCR, CUEN_CONT FROM GCMECANICOS M WHERE CVE_MEC = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_MEC.Text = dr("CVE_MEC")
                    tDescr.Text = dr("DESCR")
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                    If dr.ReadNullAsEmptyString("STATUS") = "A" Then
                        BtnActivo.Text = "Activo"
                    Else
                        BtnActivo.Text = "Baja"
                    End If
                End If
                dr.Close()

                tCVE_MEC.Enabled = False
                tDescr.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmMecanicosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmMecanicosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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
            MsgBox("El nombre del mecanico no debe quedar vacia, verifique por favor")
            Return
        End If


        SQL = "UPDATE GCMECANICOS SET CVE_MEC = @CVE_MEC, DESCR = @DESCR, CUEN_CONT = @CUEN_CONT " &
            "WHERE CVE_MEC = @CVE_MEC " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCMECANICOS (CVE_MEC, STATUS, DESCR, CUEN_CONT) VALUES(@CVE_MEC, 'A', @DESCR, @CUEN_CONT)"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_MEC", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_MEC.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    If BtnActivo.Visible Then
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCMECANICOS SET STATUS = '" & IIf(BtnActivo.Text = "Activo", "A", "B") & "' WHERE CVE_MEC = " & CInt(tCVE_MEC.Text)
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

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

    Private Sub BtnActivo_Click(sender As Object, e As EventArgs) Handles BtnActivo.Click
        Try
            If BtnActivo.Text = "Activo" Then
                BtnActivo.Text = "Baja"
            Else
                BtnActivo.Text = "Activo"
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
