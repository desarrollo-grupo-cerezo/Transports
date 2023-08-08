Imports System.Data.SqlClient
Public Class frmViajesAE
    Private Sub frmViajesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tCVE_VIAJE.MaxLength = 20
        tDescr.MaxLength = 120
        tCIUDAD.MaxLength = 60

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        tClave.Text = ""
        tCVE_VIAJE.Text = ""
        tDescr.Text = ""
        F1.Value = Now
        tCIUDAD.Text = ""
        cboEstado.SelectedIndex = -1

        CARGA_CAT()

        If Var1 = "Nuevo" Then
            Try
                tClave.Text = GET_MAX("GCVIAJES", "CLAVE")
                tClave.Enabled = False
                tCVE_VIAJE.Text = ""
                tCVE_VIAJE.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT V.CLAVE, V.CVE_VIAJE, V.DESCR, V.STATUS, V.FECHA, V.CIUDAD, V.CVE_ESTADO " &
                    "FROM GCVIAJES V WHERE CLAVE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tClave.Text = dr("CLAVE").ToString
                    tCVE_VIAJE.text = dr("CVE_VIAJE").ToString
                    tDescr.Text = dr("DESCR").ToString
                    If IsDate(dr("FECHA").ToString) Then
                        F1.Value = dr("FECHA").ToString
                    Else
                        F1.Value = Now
                    End If

                    tCIUDAD.text = dr("CIUDAD").ToString
                    Try
                        For Each vdp As ValueDescriptionPair In cboEstado.Items
                            If vdp.ValuePair = dr("CVE_ESTADO") Then
                                cboEstado.SelectedIndex = vdp.cboIndex
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                dr.Close()

                tClave.Enabled = False
                tCVE_VIAJE.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Sub CARGA_CAT()
        Dim cmd As New SqlCommand
        Dim z As Integer
        cmd.Connection = cnSAE

        Try
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(CVE_ESTADO,0) AS IDE, ISNULL(NOMBRE,'') AS NOM FROM GCESTADOS WHERE STATUS = 'A' ORDER BY NOMBRE"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboEstado.Items.Clear()
            Do While dr.Read
                cboEstado.Items.Add(New ValueDescriptionPair(dr("IDE"), dr("NOM"), dr("IDE"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub frmViajesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmViajesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim CVE_ESTADO As Integer

        Try
            If cboEstado.SelectedIndex = -1 Then
                CVE_ESTADO = 0
            Else
                CVE_ESTADO = CType(cboEstado.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCVIAJES SET CLAVE = @CLAVE, CVE_VIAJE = @CVE_VIAJE, DESCR = @DESCR, FECHA = @FECHA, CIUDAD = @CIUDAD, " &
            "CVE_ESTADO = @CVE_ESTADO " &
            "WHERE CLAVE = @CLAVE " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCVIAJES (CLAVE, CVE_VIAJE, DESCR, STATUS, FECHA, CIUDAD, CVE_ESTADO)" &
            "VALUES(@CLAVE, @CVE_VIAJE, @DESCR, 'A', @FECHA, @CIUDAD, @CVE_ESTADO)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CLAVE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tClave.Text)
            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = tCVE_VIAJE.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = F1.Value
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = tCIUDAD.Text
            cmd.Parameters.Add("@CVE_ESTADO", SqlDbType.Int).Value = CVE_ESTADO

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

    Private Sub frmViajesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()

    End Sub
End Class
