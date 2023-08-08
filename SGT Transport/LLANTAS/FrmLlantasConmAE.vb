Imports System.Data.SqlClient
Public Class FrmLlantasConmAE
    Private Sub FrmLlantasConmAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        Try
            Dim CVE_ST As Integer

            Using cmd As SqlCommand = cnSAE.CreateCommand

                SQL = "SELECT * FROM GCLLANTA_STATUS ORDER BY TRY_PARSE(CVE_STATUS AS INT)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CVE_ST = 0

                        If Not IsNothing(dr("CVE_STATUS")) Then
                            If IsNumeric(dr("CVE_STATUS")) Then
                                CVE_ST = dr("CVE_STATUS")
                            End If
                        End If
                        CboStatus.Items.Add(Format(CVE_ST, "00") & " " & dr("DESCR"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Var1 = "Nuevo" Then
            Try
                TCVE_CPTO.Text = GET_MAX("GCLLANTAS_CONM", "CVE_CPTO", 0, " WHERE TIPO_MOV = 'E'")
                GroupBox1.Enabled = True
                TCVE_CPTO.Enabled = False
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

                SQL = "SELECT N.CVE_CPTO, N.DESCR, N.STATUS_LLANTA, N.TIPO_MOV, N.STATUS, N.SIGNO
                    FROM GCLLANTAS_CONM N WHERE CVE_CPTO = " & Var2 & " AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then

                    TCVE_CPTO.Text = dr("CVE_CPTO").ToString
                    TDescr.Text = dr("DESCR").ToString

                    For k = 1 To CboStatus.Items.Count - 1
                        If dr("STATUS_LLANTA") = CInt(CboStatus.Items(k).ToString.Substring(0, 2).Trim) Then
                            CboStatus.SelectedIndex = k
                            Exit For
                        End If
                    Next
                    If dr("TIPO_MOV").ToString = "E" Then
                        RadEntrada.Checked = True
                    Else
                        RadSalida.Checked = False
                    End If
                    GroupBox1.Enabled = False
                Else
                    TCVE_CPTO.Text = ""
                    TDescr.Text = ""
                    CboStatus.SelectedIndex = -1
                    RadEntrada.Checked = True
                    GroupBox1.Enabled = True
                End If
                dr.Close()

                TCVE_CPTO.Enabled = False
                TDescr.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        Me.CenterToScreen()
    End Sub
    Private Sub FrmLlantasConmAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_CPTO As Integer = 0

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If TDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        If CboStatus.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione asociado a ")
            Return
        End If
        Try
            If IsNumeric(CboStatus.Text.Substring(0, 2).Trim) Then
                CVE_CPTO = CboStatus.Text.Substring(0, 3).Trim
            Else
                CVE_CPTO = 0
            End If
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCLLANTAS_CONM SET DESCR = @DESCR, STATUS_LLANTA = @STATUS_LLANTA, TIPO_MOV = @TIPO_MOV, SIGNO = @SIGNO
            WHERE CVE_CPTO = @CVE_CPTO
            IF @@ROWCOUNT = 0
            INSERT INTO GCLLANTAS_CONM (CVE_CPTO, DESCR, STATUS_LLANTA, TIPO_MOV, STATUS, SIGNO)
            VALUES(@CVE_CPTO, @DESCR, @STATUS_LLANTA, @TIPO_MOV, 'A', @SIGNO)"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_CPTO.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDescr.Text
            cmd.Parameters.Add("@STATUS_LLANTA", SqlDbType.VarChar).Value = CVE_CPTO
            cmd.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = IIf(RadEntrada.Checked, "E", "S")
            cmd.Parameters.Add("@SIGNO", SqlDbType.SmallInt).Value = IIf(RadEntrada.Checked, "1", "-1")
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
    Private Sub FrmLlantasConmAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub radEntrada_CheckedChanged(sender As Object, e As EventArgs) Handles RadEntrada.CheckedChanged
        If RadEntrada.Checked Then
            TCVE_CPTO.Text = GET_MAX("GCLLANTAS_CONM", "CVE_CPTO", 0, " WHERE TIPO_MOV = 'E'")
        End If
    End Sub
    Private Sub radSalida_CheckedChanged(sender As Object, e As EventArgs) Handles RadSalida.CheckedChanged
        If RadSalida.Checked Then
            Dim NUM_CONC As Integer

            NUM_CONC = GET_MAX("GCLLANTAS_CONM", "CVE_CPTO", 0, " WHERE TIPO_MOV = 'S'")
            If NUM_CONC < 50 Then
                NUM_CONC = 50
            End If

            TCVE_CPTO.Text = NUM_CONC
        End If
    End Sub
End Class
