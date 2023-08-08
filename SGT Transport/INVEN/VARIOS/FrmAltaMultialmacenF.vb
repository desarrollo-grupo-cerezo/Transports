Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmAltaMultialmacenF
    Dim CVE_ART As String

    Private Sub frmAltaMultialmacenF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        CVE_ART = Var25
        Fg.Cols(4).Width = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCALMACENESF" & Empresa & " ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                Fg.Rows.Count = 1
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_ALM") & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try

            For k = 1 To Fg.Rows.Count - 1
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM GCMULTF" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & Fg(k, 2)
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            Fg(k, 0) = "E"
                            Fg(k, 1) = True
                            Fg(k, 4) = True
                        End If
                    End Using
                End Using
            Next
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmAltaMultialmacenF_FontChanged(sender As Object, e As EventArgs) Handles Me.FontChanged
        CloseTab("Multialmacén activo fijo")
        Me.Dispose()
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Try
            Dim NUM_ALM As Integer

            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 1) Then
                        NUM_ALM = Fg(k, 2)
                        SQL = "If NOT EXISTS (SELECT CVE_ALM FROM  GCMULTF" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM & ") " &
                            "INSERT INTO GCMULTF" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, EXIST, STOCK_MIN, STOCK_MAX, COMP_X_REC, UUID, " &
                            "VERSION_SINC) VALUES('" & CVE_ART & "','" & NUM_ALM & "','A','','0', 0, 0, 0, NEWID(), GETDATE())"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            MsgBox("Proceso terminado")
            Me.Close()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 4) Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAltaMultialmacenF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()

    End Sub
End Class
