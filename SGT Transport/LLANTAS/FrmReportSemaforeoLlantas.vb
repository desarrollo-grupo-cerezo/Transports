Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Themes
Imports Stimulsoft.Report.StiOptions.Export

Public Class FrmReportSemaforeoLlantas
    Private R11 As Decimal, R12 As Decimal
    Private R21 As Decimal, R22 As Decimal
    Private R31 As Decimal, R32 As Decimal
    Private Sub FrmReportSemaforeoLlantas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Me.CenterToScreen()

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            Dim i As Integer = 1
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmReportSemaforeoLlantas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String

        Try
            Dim j As Integer = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCLLANTAS_RANGOS_DESGASTE ORDER BY CVE_DES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        Select Case j
                            Case 1
                                R11 = dr("DE")
                                R12 = dr("HASTA")
                            Case 2
                                R21 = dr("DE")
                                R22 = dr("HASTA")
                            Case 3
                                R31 = dr("DE")
                                R32 = dr("HASTA")
                        End Select
                        j += 1
                    Loop
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try '                    LEFT JOIN GCINSPEC_LLANTAS I ON I.NUM_ECONOMICO = L.NUM_ECONOMICO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_ECONOMICO, SEMAFORO, ISNULL(PROFUNDIDAD_ACTUAL,0) AS PROF_ACTUAL
                    FROM GCLLANTAS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            If dr("PROF_ACTUAL") >= R11 And dr("PROF_ACTUAL") <= R12 Then
                                SQL = "UPDATE GCINSPEC_LLANTAS SET SEMAFORO = 'R' WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                DOC_NEW = EXECUTE_QUERY_NET(SQL)
                            Else
                                If dr("PROF_ACTUAL") >= R21 And dr("PROF_ACTUAL") <= R22 Then
                                    SQL = "UPDATE GCINSPEC_LLANTAS SET SEMAFORO = 'A' WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                    DOC_NEW = EXECUTE_QUERY_NET(SQL)
                                Else
                                    If dr("PROF_ACTUAL") >= R31 And dr("PROF_ACTUAL") <= R32 Then
                                        SQL = "UPDATE GCINSPEC_LLANTAS SET SEMAFORO = 'V' WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                        DOC_NEW = EXECUTE_QUERY_NET(SQL)
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSemaforeoLLantas.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text

            'StiReport1.Item("F1") = F1.Value
            'StiReport1.Item("F2") = F2.Value

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarDisenador.Click
        PrinterMRT("ReportSemaforeoLLantas")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class