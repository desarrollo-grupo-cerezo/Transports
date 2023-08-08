Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports C1.Win.C1Command

Public Class FrmInspecDiarias
    Private Sub FrmInspecDiarias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Me.CenterToScreen()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmInspecDiarias_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim T1 As Integer, T2 As Integer, T3 As Integer, CADENA As String

        Var2 = FSQL(F1.Value)
        Var4 = FSQL(F2.Value)

        EXECUTE_QUERY_NET("TRUNCATE TABLE GCINSPEC_LLANTAS_B")

        Try
            '
            'SQL = "SELECT MAX(CVE_INS) AS CVEINS, MAX(UNIDAD) AS UNI, MAX(FECHA) AS FEC, CASE 
            '    WHEN MAX(STATUS) = 'E' THEN 'EDICION' 
            '    WHEN MAX(STATUS) = 'F' THEN 'FINALIZADO' 
            '    WHEN MAX(STATUS) = 'C' THEN 'CANCELADO' ELSE '' END AS 'Estatus'
            'From GCINSPEC_LLANTAS I 
            ' GROUP BY CVE_INS
            'ORDER BY CVE_INS DESC"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT GCINSPEC_LLANTAS.FECHA, TRACTORES.CVE_TIPO_UNI, COUNT(*), Count(DISTINCT GCINSPEC_LLANTAS.CVE_INS) AS INSPECCIONES
                        FROM GCINSPEC_LLANTAS 
                        LEFT JOIN dbo.GCUNIDADES TRACTORES ON GCINSPEC_LLANTAS.UNIDAD = TRACTORES.CLAVEMONTE
                        WHERE GCINSPEC_LLANTAS.STATUS = 'F' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "'
                        GROUP BY GCINSPEC_LLANTAS.FECHA, TRACTORES.CVE_TIPO_UNI"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            Try
                                CADENA = "" : T1 = 0 : T2 = 0 : T3 = 0
                                Select Case dr("CVE_TIPO_UNI")
                                    Case 1
                                        CADENA = ", T1 = T1 + " & dr("INSPECCIONES")
                                        T1 = dr("INSPECCIONES")
                                    Case 2
                                        CADENA = ", T2 = T2 + " & dr("INSPECCIONES")
                                        T2 = dr("INSPECCIONES")
                                    Case 3
                                        CADENA = ", T3 = T3 + " & dr("INSPECCIONES")
                                        T3 = dr("INSPECCIONES")
                                End Select
                                SQL = "IF EXISTS (SELECT CVE_TIPO_UNI FROM GCINSPEC_LLANTAS_B WHERE FECHA = '" & FSQL(dr("FECHA")) & "')
                                    UPDATE GCINSPEC_LLANTAS_B SET INSPECCIONES = INSPECCIONES + " & dr("INSPECCIONES") & " " & CADENA & " WHERE FECHA = '" & FSQL(dr("FECHA")) & "' 
                                    ELSE
                                    INSERT INTO GCINSPEC_LLANTAS_B (INSPECCIONES, FECHA, CVE_TIPO_UNI, T1, T2, T3) VALUES ('" & dr("INSPECCIONES") & "','" &
                                    FSQL(dr("FECHA")) & "','" & dr("CVE_TIPO_UNI") & "','" & T1 & "','" & T2 & "','" & T3 & "')"

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class