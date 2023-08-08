Imports System.Data.SqlClient

Public Class FrmBuscarNumEconomico
    Private Sub FrmBuscarNumEconomico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        Fg.Rows.Count = 1
    End Sub
    Private Sub BarBuscar_Click(sender As Object, e As EventArgs) Handles BarBuscar.Click
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim CVE_LLANTA As String, Pos As Integer = 0, CVE_UNI As String = ""
            cmd.Connection = cnSAE

            CVE_LLANTA = 0
            Try
                SQL = "SELECT ISNULL(CVE_LLANTA,0) AS CVE_LLA FROM GCLLANTAS WHERE STATUS <> 'B' AND NUM_ECONOMICO = '" & TNUM_ECONOMICO.Text & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    CVE_LLANTA = dr("CVE_LLA").ToString.Trim
                End If
                dr.Close()
            Catch ex As Exception
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If CVE_LLANTA = 0 Then
                MsgBox("Numero economico no encontrado")
                Return
            End If

            SQL = "SELECT CVE_LLANTA, NUM_ECONOMICO FROM GCLLANTAS WHERE STATUS <> 'B' AND NUM_ECONOMICO = '" & TNUM_ECONOMICO.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read

                CVE_LLANTA = dr("CVE_LLANTA")

                Try
                    SQL = "SELECT CLAVE, ISNULL(CLAVEMONTE,'') AS DES, ISNULL(CHLL1,'') AS C1, ISNULL(CHLL2,'') AS C2, ISNULL(CHLL3,'') AS C3, ISNULL(CHLL4,'') AS C4, " &
                    "ISNULL(CHLL5,'') AS C5, ISNULL(CHLL6,'') AS C6, ISNULL(CHLL7,'') AS C7, ISNULL(CHLL8,'') AS C8, ISNULL(CHLL9,'') AS C9, " &
                    "ISNULL(CHLL10,'') AS C10, ISNULL(CHLL11,'') AS C11, ISNULL(CHLL12,'') AS C12  " &
                    "FROM GCUNIDADES U " &
                    "WHERE ISNULL(STATUS, 'A') = 'A' AND (" &
                    "CHLL1 = '" & CVE_LLANTA & "' OR CHLL2 = '" & CVE_LLANTA & "' OR CHLL3 = '" & CVE_LLANTA & "' OR CHLL4 = '" & CVE_LLANTA & "' OR " &
                    "CHLL5 = '" & CVE_LLANTA & "' OR CHLL6 = '" & CVE_LLANTA & "' OR CHLL7 = '" & CVE_LLANTA & "' OR CHLL8 = '" & CVE_LLANTA & "' OR " &
                    "CHLL9 = '" & CVE_LLANTA & "' OR CHLL10 = '" & CVE_LLANTA & "' OR CHLL11 = '" & CVE_LLANTA & "' OR CHLL12 = '" & CVE_LLANTA & "') "
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                CVE_UNI = dr2("DES")
                                If dr2("C1").ToString = CVE_LLANTA Then Pos = 1
                                If dr2("C2").ToString = CVE_LLANTA Then Pos = 2
                                If dr2("C3").ToString = CVE_LLANTA Then Pos = 3
                                If dr2("C4").ToString = CVE_LLANTA Then Pos = 4
                                If dr2("C5").ToString = CVE_LLANTA Then Pos = 5
                                If dr2("C6").ToString = CVE_LLANTA Then Pos = 6
                                If dr2("C7").ToString = CVE_LLANTA Then Pos = 7
                                If dr2("C8").ToString = CVE_LLANTA Then Pos = 8
                                If dr2("C9").ToString = CVE_LLANTA Then Pos = 9
                                If dr2("C10").ToString = CVE_LLANTA Then Pos = 10
                                If dr2("C11").ToString = CVE_LLANTA Then Pos = 11
                                If dr2("C12").ToString = CVE_LLANTA Then Pos = 12
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Fg.AddItem("" & vbTab & dr("CVE_LLANTA") & vbTab & CVE_UNI & vbTab & IIf(Pos = 0, "", Pos) & vbTab & IIf(Pos > 0, "Asignada", ""))
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub TNUM_ECONOMICO_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUM_ECONOMICO.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                BarBuscar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmBuscarNumEconomico_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
