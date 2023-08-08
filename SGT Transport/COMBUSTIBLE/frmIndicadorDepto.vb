
Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmIndicadorDepto
    Private TIPO_TAB As Integer

    Private Sub FrmIndicadorDepto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            SplitM1.BorderWidth = 1
            SplitM1.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill


            AssignValidation(Me.tPORC_TOL, ValidationType.Only_Numbers)
            AssignValidation(Me.tPRECIO_DIESEL, ValidationType.Only_Numbers)

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

            tPORC_TOL.Text = 0
            L4.Visible = False
            tPORC_TOL.Visible = False

            tPRECIO_DIESEL.Text = 0
            tPRECIO_DIESEL.Visible = False

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(TIPO_TAB,0) AS TI_TAB FROM GCPARAMGENERALES"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TIPO_TAB = dr("TI_TAB")
                        End If
                    End Using
                End Using
                If TIPO_TAB = 2 Then
                    RadFull_Sencillo.Visible = False
                End If

            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height - 70
            Fg.Rows(0).Height = 50

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmIndicadorDepto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Indicadores del departamento")
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            If Not IsNumeric(tPORC_TOL.Text) Then
                MsgBox("Por favor capture el porcentaja de tolerancia")
                Return
            Else
            End If
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If RadCalifOper.Checked Then '1
                CALIF_OPERADOR()
                Return
            End If
            If RadRendiGlobal.Checked Then '2
                RENDIMIENTO_GLOBAL()
                Return
            End If
            If RadRendXUnidad.Checked Then '3
                RENDIMIENTO_X_UNIDAD()
            End If
            If RadMotor.Checked Then    '4
                RENDIMIENTO_MOTOR() 'RENDIMIENTO_GLOBAL()
                Return
            End If
            If RadRendXMotorFull.Checked Then '5
                RENDIMIENTO_MOTOR_FULL() 'RENDIMIENTO_GLOBAL()
                Return
            End If
            If RadRendiFull.Checked Then '7
                RENDIMIENTO_FULL()
                Return
            End If
            If RadRendiSencillo.Checked Then '10
                RENDIMIENTO_SENCILLO()
                Return
            End If
            If RadPTORalenti.Checked Then
                PTO_RALENTI()
                Return
            End If
            If RadLtsDesconXOper.Checked Then
                LTS_DESCONTAR_X_OPER()
                Return
            End If
            If RadPorcVarDiesel.Checked Then
                RENDIMIENTO_GLOBAL()
                Return
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LTS_DESCONTAR_X_OPER()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Decimal, CA2 As Decimal, CA3 As Decimal, CA4 As Decimal, CA5 As Decimal, CA6 As Decimal
        Dim CA7 As Decimal, CA8 As Decimal, CA9 As Decimal, CA10 As Decimal, CA11 As Decimal

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 15

            Fg(0, 1) = "Operador"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "No. Viajes"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Rendimiento real"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Lts. reales vs Lts. ECM"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Lts. reales vs Lts. TAB"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Porc. var. real vs ECM"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Porc. var. real vs TAB"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Lts. a descontar"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Calif. F.C."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Calif. ralenti"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Calif. final"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Bono"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA) ORDER BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")
                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")
                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA6 / CA7) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If


                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using


            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Sub PTO_RALENTI()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Decimal, CA2 As Decimal, CA3 As Decimal, CA4 As Decimal, CA5 As Decimal, CA6 As Decimal
        Dim CA7 As Decimal, CA8 As Decimal, CA9 As Decimal, CA10 As Decimal, CA11 As Decimal

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 15

            Fg(0, 1) = "Operador"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "No. Viajes"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Rendimiento real"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Lts. reales vs Lts. ECM"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Lts. reales vs Lts. TAB"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Porc. var. real vs ECM"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Porc. var. real vs TAB"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Lts. a descontar"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Calif. F.C."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Calif. ralenti"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Calif. final"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Bono"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA) ORDER BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")
                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")
                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA6 / CA7) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If


                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using


            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Sub RENDIMIENTO_X_UNIDAD()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Decimal, CA2 As Decimal, CA3 As Decimal, CA4 As Decimal, CA5 As Decimal, CA6 As Decimal
        Dim CA7 As Decimal, CA8 As Decimal, CA9 As Decimal, CA10 As Decimal, CA11 As Decimal

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 15

            Fg(0, 1) = "Operador"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "No. Viajes"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Rendimiento real"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Lts. reales vs Lts. ECM"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Lts. reales vs Lts. TAB"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Porc. var. real vs ECM"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Porc. var. real vs TAB"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Lts. a descontar"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Calif. F.C."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Calif. ralenti"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Calif. final"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Bono"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")
                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")
                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA6 / CA7) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If


                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Sub CALIF_OPERADOR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Decimal, CA2 As Decimal, CA3 As Decimal, CA4 As Decimal, CA5 As Decimal, CA6 As Decimal
        Dim CA7 As Decimal, CA8 As Decimal, CA9 As Decimal, CA10 As Decimal, CA11 As Decimal

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 15

            Fg(0, 1) = "Operador"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "No. Viajes"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Rendimiento real"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Lts. reales vs Lts. ECM"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Lts. reales vs Lts. TAB"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Porc. var. real vs ECM"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Porc. var. real vs TAB"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Lts. a descontar"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Calif. F.C."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Calif. ralenti"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Calif. final"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Bono"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA) ORDER BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")
                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")
                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA6 / CA7) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If


                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using


            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Sub RENDIMIENTO_GLOBAL()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Double, CA2 As Double, CA3 As Double, CA4 As Double, CA5 As Double, CA6 As Double
        Dim CA7 As Double, CA8 As Double, CA9 As Double, CA10 As Double, CA11 As Double

        Dim SA1 As Double = 0, SA2 As Double = 0, SA3 As Double = 0, SA4 As Double = 0, SA5 As Double = 0, SA6 As Double = 0
        Dim SA7 As Double = 0, SA8 As Double = 0, SA9 As Double = 0, SA10 As Double = 0, SA11 As Double = 0
        Dim z As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 8

            Fg(0, 1) = "Mes"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "Rendimiento real"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Porc. var. rend. real entre rend. ECM"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Porc. var. rend. real vs rend. TAB"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Porc. var. rend. TAB vs rend. ECM"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Try
                SQL = "DELETE FROM GCREPORT1"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB, ISNULL(COUNT(*),1) AS NREG
                FROM GCRESETEO R
                WHERE (ESTADO = 'FINALIZADO' OR ESTADO = 'EN LIQUIDACION' ) AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")
                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")
                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        SA1 = SA1 + CA1
                        SA2 = SA2 + CA2
                        SA3 = SA3 + CA3
                        SA4 = SA4 + CA4
                        SA5 = SA5 + CA5

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA3 / CA4) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        'RENDIMIENTO TAB
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If
                        z = z + dr("NREG")
                        '                            1               2             3             4             5              6             7   
                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                If SA3 > 0 Then
                    SA6 = SA1 / SA3
                Else
                    SA6 = 0
                End If
                If SA4 > 0 Then
                    SA7 = SA1 / SA4
                Else
                    SA7 = 0
                End If
                If SA5 > 0 Then
                    SA8 = SA2 / SA5
                Else
                    SA8 = 0
                End If

                If SA7 > 0 Then
                    SA9 = ((SA3 / SA4) - 1) * 100
                Else
                    SA9 = 0
                End If
                'RENDIMIENTO TAB
                If SA8 > 0 Then
                    SA10 = ((SA6 / SA8) - 1) * 100
                Else
                    SA10 = 0
                End If
                If SA7 > 0 Then
                    SA11 = ((SA8 / SA7) - 1) * 100
                Else
                    SA11 = 0
                End If

                If z > 0 Then
                    CA1 = SA6
                    CA2 = SA7
                    CA3 = SA8
                    CA4 = SA9
                    CA5 = SA10
                    CA6 = SA11
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Sub RENDIMIENTO_MOTOR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Double, CA2 As Double, CA3 As Double, CA4 As Double, CA5 As Double, CA6 As Double
        Dim CA7 As Double, CA8 As Double, CA9 As Double, CA10 As Double, CA11 As Double

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 8

            Fg(0, 1) = "Mes"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "Rendimiento real"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Porc. var. rend. real entre rend. ECM"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Porc. var. rend. real vs rend. TAB"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Porc. var. rend. TAB vs rend. ECM"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Try
                SQL = "DELETE FROM GCREPORT1"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")

                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")

                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA3 / CA4) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        'RENDIMIENTO TAB
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If

                        '                            1               2             3             4             5              6             7   
                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Sub RENDIMIENTO_MOTOR_FULL()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Double, CA2 As Double, CA3 As Double, CA4 As Double, CA5 As Double, CA6 As Double
        Dim CA7 As Double, CA8 As Double, CA9 As Double, CA10 As Double, CA11 As Double

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 8

            Fg(0, 1) = "Mes"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "Rendimiento real"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Porc. var. rend. real entre rend. ECM"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Porc. var. rend. real vs rend. TAB"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Porc. var. rend. TAB vs rend. ECM"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Try
                SQL = "DELETE FROM GCREPORT1"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")

                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")

                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA3 / CA4) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        'RENDIMIENTO TAB
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If

                        '                            1               2             3             4             5              6             7   
                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Sub RENDIMIENTO_MOTOR_SENCILLO()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Double, CA2 As Double, CA3 As Double, CA4 As Double, CA5 As Double, CA6 As Double
        Dim CA7 As Double, CA8 As Double, CA9 As Double, CA10 As Double, CA11 As Double

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 8

            Fg(0, 1) = "Mes"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "Rendimiento real"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Porc. var. rend. real entre rend. ECM"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Porc. var. rend. real vs rend. TAB"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Porc. var. rend. TAB vs rend. ECM"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Try
                SQL = "DELETE FROM GCREPORT1"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")

                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")

                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA3 / CA4) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        'RENDIMIENTO TAB
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If

                        '                            1               2             3             4             5              6             7   
                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Sub RENDIMIENTO_FULL()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Double, CA2 As Double, CA3 As Double, CA4 As Double, CA5 As Double, CA6 As Double
        Dim CA7 As Double, CA8 As Double, CA9 As Double, CA10 As Double, CA11 As Double

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 8

            Fg(0, 1) = "Mes"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "Rendimiento real"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Porc. var. rend. real entre rend. ECM"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Porc. var. rend. real vs rend. TAB"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Porc. var. rend. TAB vs rend. ECM"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Try
                SQL = "DELETE FROM GCREPORT1"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")

                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")

                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA3 / CA4) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        'RENDIMIENTO TAB
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If
                        '                            1               2             3             4             5              6             7   
                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Sub RENDIMIENTO_SENCILLO()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CA1 As Double, CA2 As Double, CA3 As Double, CA4 As Double, CA5 As Double, CA6 As Double
        Dim CA7 As Double, CA8 As Double, CA9 As Double, CA10 As Double, CA11 As Double

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False

        Try
            Fg.Cols.Count = 8

            Fg(0, 1) = "Mes"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "Rendimiento real"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Decimal)
            Fg.Cols(2).Format = "###,###,##0.00"

            Fg(0, 3) = "Rendimiento ECM"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Rendimiento TAB"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Porc. var. rend. real entre rend. ECM"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Porc. var. rend. real vs rend. TAB"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Porc. var. rend. TAB vs rend. ECM"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Try
                SQL = "DELETE FROM GCREPORT1"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Rows.Count = 1

            SQL = "SELECT MONTH(FECHA) AS MES, SUM(KM_ECM) AS SUM_KM_ECM, SUM(LTS_REAL) AS SUM_LTS_REAL, SUM(LTS_TAB) AS SUM_LTS_TAB, 
                SUM(LTS_ECM) AS SUM_LTS_ECM, SUM(KMS_TAB) AS SUM_KM_TAB
                FROM GCRESETEO R
                WHERE ESTADO = 'FINALIZADO' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                GROUP BY MONTH(FECHA)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CA1 = dr.ReadNullAsEmptyDecimal("SUM_KM_ECM")
                        CA2 = dr.ReadNullAsEmptyDecimal("SUM_KM_TAB")

                        CA3 = dr.ReadNullAsEmptyDecimal("SUM_LTS_REAL")
                        CA4 = dr.ReadNullAsEmptyDecimal("SUM_LTS_ECM")

                        CA5 = dr.ReadNullAsEmptyDecimal("SUM_LTS_TAB")

                        If CA3 > 0 Then
                            CA6 = CA1 / CA3
                        Else
                            CA6 = 0
                        End If
                        If CA4 > 0 Then
                            CA7 = CA1 / CA4
                        Else
                            CA7 = 0
                        End If
                        If CA5 > 0 Then
                            CA8 = CA2 / CA5
                        Else
                            CA8 = 0
                        End If

                        If CA7 > 0 Then
                            CA9 = ((CA3 / CA4) - 1) * 100
                        Else
                            CA9 = 0
                        End If
                        'RENDIMIENTO TAB
                        If CA8 > 0 Then
                            CA10 = ((CA6 / CA8) - 1) * 100
                        Else
                            CA10 = 0
                        End If
                        If CA7 > 0 Then
                            CA11 = ((CA8 / CA7) - 1) * 100
                        Else
                            CA11 = 0
                        End If
                        '                            1               2             3             4             5              6             7   
                        Fg.AddItem("" & vbTab & dr("MES") & vbTab & CA6 & vbTab & CA7 & vbTab & CA8 & vbTab & CA9 & vbTab & CA10 & vbTab & CA11)

                        Try
                            SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('" & dr("MES") & "','" & MonthName(dr("MES")) & "','" &
                                Math.Round(CA6, 2) & "','" & Math.Round(CA7, 2) & "','" & Math.Round(CA8, 2) & "','" &
                                Math.Round(CA9, 2) & "','" & Math.Round(CA10, 2) & "','" & Math.Round(CA11, 2) & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Try
                CA1 = 0 : CA2 = 0 : CA3 = 0 : CA4 = 0 : CA5 = 0 : CA6 = 0
                Dim z As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    CA1 = CA1 + Fg(k, 2)
                    CA2 = CA2 + Fg(k, 3)
                    CA3 = CA3 + Fg(k, 4)
                    CA4 = CA4 + Fg(k, 5)
                    CA5 = CA5 + Fg(k, 6)
                    CA6 = CA6 + Fg(k, 7)
                    z = z + 1
                Next
                If z > 0 Then
                    CA1 = CA1 / z
                    CA2 = CA2 / z
                    CA3 = CA3 / z
                    CA4 = CA4 / z
                    CA5 = CA5 / z
                    CA6 = CA6 / z
                End If

                Fg.AddItem("" & vbTab & "Global" & vbTab & CA1 & vbTab & CA2 & vbTab & CA3 & vbTab & CA4 & vbTab & CA5 & vbTab & CA6)
                SQL = "INSERT INTO GCREPORT1 (NMES, MES, C1, C2, C3, C4, C5, C6) VALUES ('13','Global','" &
                    Math.Round(CA1, 2) & "','" & Math.Round(CA2, 2) & "','" & Math.Round(CA3, 2) & "','" &
                    Math.Round(CA4, 2) & "','" & Math.Round(CA5, 2) & "','" & Math.Round(CA6, 2) & "')"
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            If Fg.Rows.Count - 1 = 1 Then
                MsgBox("Proceso terminado")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click

    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String = GET_RUTA_FORMATOS(), ARCHIVO As String

        If RadAnalisisRutas.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportAnalisisRutas.mrt"

                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                'StiReport1.Item("F1") = F1.Value
                'StiReport1.Item("F2") = F2.Value
                StiReport1("FSQL1") = FSQL(F1.Value) ' .ToString.Substring(0, 10)
                StiReport1("FSQL2") = FSQL(F2.Value) ' .ToString.Substring(0, 10)

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Return
        End If
        If RadBonoPorTab.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportBonoPorTab.mrt"

                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value
                StiReport1.Item("F3") = F1.Value
                StiReport1.Item("F4") = F2.Value
                StiReport1("F5") = F1.Value.ToString.Substring(0, 10)
                StiReport1("F6") = F2.Value.ToString.Substring(0, 10)

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If RadCalifOper.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportEvaluacionMensual.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value
                StiReport1.Item("F3") = F1.Value
                StiReport1.Item("F4") = F2.Value
                StiReport1.Item("F5") = F1.Value
                StiReport1.Item("F6") = F2.Value
                StiReport1("PORC_TOLERANCIA") = CDec(tPORC_TOL.Text)

                StiReport1.Render()
                'StiReport1.Print(True)
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If RadRendiGlobal.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportIndiDepto.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If RadPorcVarDiesel.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportVariacionDiesel.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        If RadRendXUnidad.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportRendXUnidad.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value
                StiReport1.Item("F3") = F1.Value
                StiReport1.Item("F4") = F2.Value

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        'RENDIMIENTO FULL AQUI TETENOMO EL PROBLEMA CON LA GRAPHICA
        If RadRendiFull.Checked Then
            Dim ReportOk As Boolean = True, CADENA As String

            '▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
            If ReportOk Then

                Dim t2 As DataTable = DataSet2.Tables(0)
                Dim r2 As DataRow
                DataSet2.Clear()

                'dbo.GCCATEVA.TIPO_VIAJE = " & IIf(RadFull.Checked, 0, 1) & "

                If RadFull.Checked Then
                    CADENA = " AND dbo.GCCATEVA.TIPO_VIAJE = 1"
                ElseIf RadSencillo.Checked Then
                    CADENA = " AND dbo.GCCATEVA.TIPO_VIAJE = 0"
                ElseIf RadFull_Sencillo.Checked Then
                    CADENA = " AND dbo.GCCATEVA.TIPO_VIAJE = 2"
                Else
                    CADENA = " AND dbo.GCCATEVA.TIPO_VIAJE = 1"
                End If

                If TIPO_TAB = 2 Then
                    SQL = "SELECT Count(*) AS VIAJES,
                        Sum(dbo.GCRESETEO.KM_ECM) AS KMSECM, Sum(dbo.GCRESETEO.LTS_ECM) AS LTSECM, Sum(dbo.GCRESETEO.LTS_REAL) AS LTSREAL, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_ECM) > 0 THEN Sum(dbo.GCRESETEO.KM_ECM) / Sum(dbo.GCRESETEO.LTS_ECM) ELSE 0 END AS REND_ECM, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_REAL) > 0 THEN Sum(dbo.GCRESETEO.KM_ECM) / Sum(dbo.GCRESETEO.LTS_REAL) ELSE 0 END AS REND_REAL, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_ECM) > 0 THEN (Sum(dbo.GCRESETEO.LTS_REAL) / Sum(dbo.GCRESETEO.LTS_ECM)) - 1 ELSE 0 END AS P_VAR_LTS_REAL_VS_LTS_ECM, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_ECM) > 0 THEN Sum(dbo.GCRESETEO.LTS_PTO_RALENTI) / Sum(dbo.GCRESETEO.LTS_ECM) ELSE 0 END AS P_RALENTI, 
                        Max(dbo.GCMARCAUNIDAD.DESCR) AS MARCA, Max(dbo.GCMOTORES.DESCR) AS DESCR_MOTOR, Max(dbo.GCMOTORES.MOTOR) AS NOMBRE_MOTOR, 
                        CASE WHEN dbo.GCMOTORES.TIPO_VIAJE = 0 THEN 'Full' 
                        WHEN dbo.GCMOTORES.TIPO_VIAJE = 1 THEN 'Sencillo' 
                        WHEN dbo.GCMOTORES.TIPO_VIAJE = 2 THEN 'Full/Sencillo' ELSE '' END AS T_VIAJE, 
                        Sum(dbo.GCRESETEO.LTS_PTO_RALENTI) AS LTSPTO
                        FROM dbo.GCRESETEO 
                        LEFT JOIN dbo.GCUNIDADES ON dbo.GCRESETEO.CVE_UNI = dbo.GCUNIDADES.CLAVE 
                        LEFT JOIN dbo.GCMARCAUNIDAD ON dbo.GCUNIDADES.CVE_MARCA = dbo.GCMARCAUNIDAD.CVE_MARCA
                        LEFT JOIN dbo.GCCATEVA ON dbo.GCRESETEO.CVE_MOT = dbo.GCCATEVA.CVE_MOT 
                        LEFT JOIN dbo.GCMOTORES ON dbo.GCRESETEO.CVE_MOT = dbo.GCMOTORES.CVE_MOT
                        WHERE dbo.GCRESETEO.STATUS = 'A' AND dbo.GCMOTORES.STATUS = 'A' AND (dbo.GCRESETEO.ESTADO = 'FINALIZADO' OR dbo.GCRESETEO.ESTADO = 'EN LIQUIDACION') AND 
                        dbo.GCRESETEO.FECHA BETWEEN '" & FSQL(F1.Value) & "' AND '" & FSQL(F2.Value) & "' " & CADENA & "
                        GROUP BY dbo.GCMOTORES.MOTOR, dbo.GCCATEVA.TIPO_VIAJE"
                Else
                    SQL = "SELECT Count(*) AS VIAJES,
                        Sum(dbo.GCRESETEO.KM_ECM) AS KMSECM, Sum(dbo.GCRESETEO.LTS_ECM) AS LTSECM, Sum(dbo.GCRESETEO.LTS_REAL) AS LTSREAL, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_ECM) > 0 THEN Sum(dbo.GCRESETEO.KM_ECM) / Sum(dbo.GCRESETEO.LTS_ECM) ELSE 0 END AS REND_ECM, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_REAL) > 0 THEN Sum(dbo.GCRESETEO.KM_ECM) / Sum(dbo.GCRESETEO.LTS_REAL) ELSE 0 END AS REND_REAL, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_ECM) > 0 THEN (Sum(dbo.GCRESETEO.LTS_REAL) / Sum(dbo.GCRESETEO.LTS_ECM)) - 1 ELSE 0 END AS P_VAR_LTS_REAL_VS_LTS_ECM, 
                        CASE WHEN Sum(dbo.GCRESETEO.LTS_ECM) > 0 THEN Sum(dbo.GCRESETEO.LTS_PTO_RALENTI) / Sum(dbo.GCRESETEO.LTS_ECM) ELSE 0 END AS P_RALENTI, 
                        Max(dbo.GCMARCAUNIDAD.DESCR) AS MARCA, Max(dbo.GCMOTORES.DESCR) AS DESCR_MOTOR, Max(dbo.GCMOTORES.MOTOR) AS NOMBRE_MOTOR, 
                        CASE WHEN dbo.GCCATEVA.TIPO_VIAJE = 1 THEN 'Full' 
                        WHEN dbo.GCCATEVA.TIPO_VIAJE = 0 THEN 'Sencillo' 
                        WHEN dbo.GCCATEVA.TIPO_VIAJE = 2 THEN 'Full/Sencillo' ELSE '' END AS T_VIAJE, 
                        Sum(dbo.GCRESETEO.LTS_PTO_RALENTI) AS LTSPTO
                        FROM dbo.GCRESETEO 
                        LEFT JOIN dbo.GCUNIDADES ON dbo.GCRESETEO.CVE_UNI = dbo.GCUNIDADES.CLAVE 
                        LEFT JOIN dbo.GCMARCAUNIDAD ON dbo.GCUNIDADES.CVE_MARCA = dbo.GCMARCAUNIDAD.CVE_MARCA
                        LEFT JOIN dbo.GCCATEVA ON dbo.GCRESETEO.CVE_EVA = dbo.GCCATEVA.CVE_EVA
                        LEFT JOIN dbo.GCMOTORES ON dbo.GCRESETEO.CVE_MOT = dbo.GCMOTORES.CVE_MOT
                        WHERE dbo.GCRESETEO.STATUS = 'A' AND (dbo.GCRESETEO.ESTADO = 'FINALIZADO' OR dbo.GCRESETEO.ESTADO = 'EN LIQUIDACION') AND 
                        dbo.GCRESETEO.FECHA BETWEEN '" & FSQL(F1.Value) & "' AND '" & FSQL(F2.Value) & "' " & CADENA & "
                        GROUP BY dbo.GCMOTORES.MOTOR, dbo.GCCATEVA.TIPO_VIAJE"
                End If

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read

                                r2 = t2.NewRow()
                                r2("VIAJES") = dr("VIAJES")
                                r2("KMSECM") = dr("KMSECM")
                                r2("LTSECM") = dr("LTSECM")
                                r2("REND_ECM") = dr("REND_ECM")
                                r2("LTSREAL") = dr("LTSREAL")
                                r2("REND_REAL") = dr("REND_REAL")
                                r2("P_VAR_LTS_REAL_VS_LTS_ECM") = dr("P_VAR_LTS_REAL_VS_LTS_ECM")
                                r2("P_RALENTI") = dr("P_RALENTI")
                                r2("MARCA") = dr("MARCA")
                                r2("DESCR_MOTOR") = dr("DESCR_MOTOR")
                                r2("NOMBRE_MOTOR") = dr("NOMBRE_MOTOR")
                                r2("T_VIAJE") = dr("T_VIAJE")
                                r2("LTSPTO") = dr("LTSPTO")
                                r2("FEC1") = F1.Value.ToString.Substring(0, 10)
                                r2("FEC2") = F2.Value.ToString.Substring(0, 10)
                                If RadFull.Checked Then
                                    r2("TIPO_VIAJE") = "Full"
                                ElseIf RadSencillo.Checked Then
                                    r2("TIPO_VIAJE") = "Sencillo"
                                Else
                                    r2("TIPO_VIAJE") = "Full/Sencillo"
                                End If
                                t2.Rows.Add(r2)
                            End While
                        End Using
                    End Using

                    ARCHIVO = RUTA_FORMATOS & "\ReportRendFull.mrt"
                    If Not File.Exists(ARCHIVO) Then
                        MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                        Return
                    End If

                    StiReport1.Load(ARCHIVO)

                    Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                    StiReport1.Dictionary.Databases.Clear()
                    StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                    StiReport1.RegData(DataSet2)


                    StiReport1.Compile()
                    StiReport1.Dictionary.Synchronize()
                    StiReport1.ReportName = Me.Text
                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value

                    If RadFull.Checked Then
                        StiReport1.Item("TVIAJE") = 1
                    ElseIf RadSencillo.Checked Then
                        StiReport1.Item("TVIAJE") = 0
                    Else
                        StiReport1.Item("TVIAJE") = 2
                    End If

                    If RadFull.Checked Then
                        StiReport1("TIPO_VIAJE2") = "Full"
                    ElseIf RadSencillo.Checked Then
                        StiReport1("TIPO_VIAJE2") = "Sencillo"
                    Else
                        StiReport1("TIPO_VIAJE2") = "Full/Sencillo"
                    End If
                    StiReport1.Render()

                    If PASS_GRUPOCE.ToUpper = "BUS" Then
                        'StiReport1.Design()
                        StiReport1.Show()
                    Else
                        StiReport1.Show()
                    End If

                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try


            Else
                Try
                    ARCHIVO = RUTA_FORMATOS & "\ReportRendFull.mrt"
                    If Not File.Exists(ARCHIVO) Then
                        MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                        Return
                    End If



                    StiReport1.Load(ARCHIVO)

                    Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                        Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                    StiReport1.Dictionary.Databases.Clear()
                    StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                    StiReport1.Compile()
                    StiReport1.Dictionary.Synchronize()
                    StiReport1.ReportName = Me.Text
                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value
                    StiReport1.Item("F3") = F1.Value
                    StiReport1.Item("F4") = F2.Value


                    StiReport1.Render()
                    StiReport1.Show()
                Catch ex As Exception
                    Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                    MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

        End If
        'RENDIMIENTO SENCILLO
        If RadRendiSencillo.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportRendSencillo.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value
                StiReport1.Item("F3") = F1.Value
                StiReport1.Item("F4") = F2.Value

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        'RENDIMIENTO_MOTOR
        If RadMotor.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportXMotor.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value
                StiReport1.Item("F3") = F1.Value
                StiReport1.Item("F4") = F2.Value

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        'RENDIMIENTO_MOTOR_FULL
        If RadRendXMotorFull.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportRendXMotorFull.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value
                StiReport1.Item("F3") = F1.Value
                StiReport1.Item("F4") = F2.Value

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        'RENDIMIENTO_MOTOR_SENCILLO
        If RadPTORalenti.Checked Then
            Try
                ARCHIVO = RUTA_FORMATOS & "\ReportPTORalenti.mrt"
                If Not File.Exists(ARCHIVO) Then
                    MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                    Return
                End If

                StiReport1.Load(ARCHIVO)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("F1") = F1.Value
                StiReport1.Item("F2") = F2.Value
                StiReport1.Item("F3") = F1.Value
                StiReport1.Item("F4") = F2.Value
                StiReport1.Item("F5") = F1.Value
                StiReport1.Item("F6") = F2.Value

                If Not IsNumeric(tPRECIO_DIESEL.Text) Then
                    tPRECIO_DIESEL.Text = 0
                End If

                StiReport1("PRECIO_DIESEL") = CDec(tPRECIO_DIESEL.Text)

                StiReport1.Render()
                'StiReport1.Print(True)
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If RadLtsDesconXOper.Checked Then

            If RadEvento1.Checked Then
                Try
                    Dim FECHA1 As String, FECHA2 As String

                    FECHA1 = F1.Value.ToString.Substring(0, 10)
                    FECHA2 = F2.Value.ToString.Substring(0, 10)

                    Try
                        ARCHIVO = RUTA_FORMATOS & "\ReportLtsDescontarXOperDS.mrt"

                        If Not File.Exists(ARCHIVO) Then
                            MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                            Return
                        End If

                        StiReport1.Load(ARCHIVO)

                        Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                            Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                        StiReport1.Dictionary.Databases.Clear()
                        StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                        StiReport1.Compile()
                        StiReport1.Dictionary.Synchronize()
                        StiReport1.ReportName = Me.Text
                        StiReport1.Item("F1") = F1.Value
                        StiReport1.Item("F2") = F2.Value
                        StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
                        StiReport1("F4") = F2.Value.ToString.Substring(0, 10)

                        StiReport1.Render()
                        StiReport1.Show()
                    Catch ex As Exception
                        Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                        MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Catch ex As Exception
                    Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                    MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                Try
                    If RadLtsECM.Checked Then
                        ARCHIVO = RUTA_FORMATOS & "\ReportLtsDescEven2ECM.mrt"
                    Else
                        ARCHIVO = RUTA_FORMATOS & "\ReportLtsDescEven2TAB.mrt"
                    End If

                    If Not File.Exists(ARCHIVO) Then
                        MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                        Return
                    End If

                    StiReport1.Load(ARCHIVO)

                    Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                    StiReport1.Dictionary.Databases.Clear()
                    StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                    StiReport1.Compile()
                    StiReport1.Dictionary.Synchronize()
                    StiReport1.ReportName = Me.Text
                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value
                    StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
                    StiReport1("F4") = F2.Value.ToString.Substring(0, 10)

                    StiReport1.Render()
                    StiReport1.Show()
                Catch ex As Exception
                    Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                    MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        End If
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub RadCalifOper_CheckedChanged(sender As Object, e As EventArgs) Handles RadCalifOper.CheckedChanged
        Try
            If RadCalifOper.Checked Then
                L4.Visible = True
                tPORC_TOL.Visible = True
            Else
                L4.Visible = False
                tPORC_TOL.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadPTORalenti_CheckedChanged(sender As Object, e As EventArgs) Handles RadPTORalenti.CheckedChanged
        Try
            If RadPTORalenti.Checked Then
                L5.Visible = True
                tPRECIO_DIESEL.Visible = True
            Else
                L5.Visible = False
                tPRECIO_DIESEL.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadEvento1_CheckedChanged(sender As Object, e As EventArgs) Handles RadEvento1.CheckedChanged
        If RadEvento1.Checked Then
            PnlSubEvento2.Visible = False
        End If
    End Sub

    Private Sub RadEvento2_CheckedChanged(sender As Object, e As EventArgs) Handles RadEvento2.CheckedChanged
        If RadEvento2.Checked Then
            PnlSubEvento2.Visible = True
        End If
    End Sub
End Class
