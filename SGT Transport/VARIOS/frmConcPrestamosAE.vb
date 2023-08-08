Imports System.Data.SqlClient
Public Class frmConcPrestamosAE
    Private Sub frmConcPrestamosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        tDescr.MaxLength = 120
        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                tNUM_CPTO.Text = GET_MAX("GCCONC_PRESTAMOS", "NUM_CPTO")
                tNUM_CPTO.Enabled = False
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

                SQL = "SELECT C.NUM_CPTO, C.DESCR, C.STATUS, CUEN_CONT FROM GCCONC_PRESTAMOS C WHERE NUM_CPTO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tNUM_CPTO.Text = dr("NUM_CPTO").ToString
                    tDescr.Text = dr("DESCR").ToString
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                Else
                    tNUM_CPTO.Text = 0
                    tDescr.Text = ""
                End If
                dr.Close()

                tNUM_CPTO.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmConcPrestamosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmConcPrestamosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCCONC_PRESTAMOS SET DESCR = @DESCR, CUEN_CONT = @CUEN_CONT " &
            "WHERE  NUM_CPTO = @NUM_CPTO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCCONC_PRESTAMOS (NUM_CPTO, DESCR, STATUS, GUID, CUEN_CONT) VALUES(@NUM_CPTO, @DESCR, 'A', NEWID(), @CUEN_CONT)"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@NUM_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tNUM_CPTO.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
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
