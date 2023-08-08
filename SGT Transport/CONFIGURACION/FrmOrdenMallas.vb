Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmOrdenMallas
    Private Sub FrmOrdenMallas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Me.CenterToScreen()

        Fg.Cols(1).StarWidth = "2*"
        Fg.Cols(2).StarWidth = "3*"
        Fg.Cols(3).StarWidth = "*"
        Fg.Cols(4).StarWidth = "*"

        Fg.SetCellCheck(0, 4, C1.Win.C1FlexGrid.CheckEnum.Unchecked)

        'CboModulo.Items.Add(New ValueDescriptionPair("RESETEO", "Reseteo 1", 0, 1, 1))
        'CboModulo.Items.Add(New ValueDescriptionPair("RESETEO", "Reseteo 2", 1, 1, 2))
        DESPLEGAR()

    End Sub
    Private Sub FrmOrdenMallas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarAceptar_Click(sender As Object, e As ClickEventArgs) Handles BarAceptar.Click
        Try
            For k = 1 To Fg.Rows.Count - 1

                SQL = "UPDATE GCCAMPO_X_MALLA SET LEYENDA_N = '" & Fg(k, 2) & "', 
                    VISIBLE = " & IIf(Fg(k, 4), 1, 0) & "
                    WHERE MODULO = 'RESETEO' AND PROCESO = '0' AND CAMPO = '" & Fg(k, 1) & "'"
                EXECUTE_QUERY_NET(SQL)
            Next
            MsgBox("El datos se grabaron correctamente")

            'CboModulo_SelectedIndexChanged(Nothing, Nothing)

            Var25 = "SI"
            Me.Close()

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub DESPLEGAR()
        Try
            Dim z As Integer = 0

            Fg.Redraw = False
            Fg.BeginUpdate()
            Me.Cursor = Cursors.WaitCursor


            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CAMPO, LEYENDA_N, ORDEN_N, VISIBLE 
                    FROM GCCAMPO_X_MALLA 
                    WHERE 
                    MODULO = 'RESETEO' AND PROCESO = '0'
                    ORDER BY ORDEN_N"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CAMPO") & vbTab & dr("LEYENDA_N") & vbTab &
                                   dr("ORDEN_N") & vbTab & dr("VISIBLE"))
                        z += 1
                    End While
                End Using

                'Dim z1 As Integer = 0, z2 As Integer = 0, z3 As Integer = 0
                'For k = 1 To Fg.Rows.Count - 1
                'If Fg(k, 1) = "VELMAX" Then
                'z1 = 1
                'End If
                'If Fg(k, 1) = "RPM_MAX" Then
                'z2 = 1
                'End If
                'If Fg(k, 1) = "CALIF_RPM" Then
                'z3 = 1
                'End If
                'Next
                'If z1 = 0 Then
                'SQL = "INSERT INTO GCCAMPO_X_MALLA (MODULO, PROCESO, CAMPO, TIPO_CAMPO, ALINEADO, LEYENDA, ORDEN_O, ORDEN_N, 
                '       VISIBLE, LEYENDA_N) VALUES         (RESETEO', '0', 'VELMAX', 'DECIMAL', ' ', 'Velocidad máxima'," & GET_MAX("GCCAMPO_X_MALLA", "ORDEN_O") &                        "," & GET_MAX("GCCAMPO_X_MALLA", "ORDEN_O") & ", 0, 'Velocidad máxima')"
                'EXECUTE_QUERY_NET(SQL)
                'End If
                'If z2 = 0 Then
                '   SQL = "INSERT INTO GCCAMPO_X_MALLA (MODULO, PROCESO, CAMPO, TIPO_CAMPO, ALINEADO, LEYENDA, ORDEN_O, ORDEN_N,                         VISIBLE, LEYENDA_N) VALUES
                '(RESETEO', '0', 'RPM_MAX', 'DECIMAL', ' ', 'RPM Máxima'," & GET_MAX("GCCAMPO_X_MALLA", "ORDEN_O") &                        "," & GET_MAX("GCCAMPO_X_MALLA", "ORDEN_O") & ", 0, 'RPM Máxima')"
                'EXECUTE_QUERY_NET(SQL)
                'End If
                'If z3 = 0 Then
                '   SQL = "INSERT INTO GCCAMPO_X_MALLA (MODULO, PROCESO, CAMPO, TIPO_CAMPO, ALINEADO, LEYENDA, ORDEN_O, ORDEN_N,                         VISIBLE, LEYENDA_N) VALUES
                '(RESETEO', '0', 'CALIF_RPM', 'DECIMAL', ' ', 'Calif. RPM'," & GET_MAX("GCCAMPO_X_MALLA", "ORDEN_O") &
                '"," & GET_MAX("GCCAMPO_X_MALLA", "ORDEN_O") & ", 0, 'Calif. RPM')"
                'EXECUTE_QUERY_NET(SQL)
                'End If

                'If z1 = 0 Or z2 = 0 Or z3 = 0 Then
                'Fg.Rows.Count = 1

                'Using cmd4 As SqlCommand = cnSAE.CreateCommand
                'SQL = "SELECT CAMPO, LEYENDA_N, ORDEN_N, VISIBLE 
                'From ' GCCAMPO_X_MALLA 
                'WHERE 
                'MODULO = 'RESETEO' AND PROCESO = '0'
                'ORDER BY ORDEN_N"

                'cmd4.CommandText = SQL
                'Using dr As SqlDataReader = cmd4.ExecuteReader
                'While dr.Read
                'Fg.AddItem("" & vbTab & dr("CAMPO") & vbTab & dr("LEYENDA_N") & vbTab &
                'dr("ORDEN_N") & vbTab & dr("VISIBLE"))
                'End While
                'End Using
                'End Using
                'End If
                'Fg.AutoSizeCols()

            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BarRestablecer_Click(sender As Object, e As ClickEventArgs) Handles BarRestablecer.Click
        Try
            Fg.Redraw = False
            Fg.BeginUpdate()
            Me.Cursor = Cursors.WaitCursor

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCAMPO_X_MALLA ORDER BY ORDEN_O"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        SQL = "UPDATE GCCAMPO_X_MALLA SET LEYENDA_N = '" & dr("LEYENDA").ToString.Replace("'", "") & "', 
                            ORDEN_N = " & dr("ORDEN_O") & ", VISIBLE = 1
                            WHERE MODULO = 'RESETEO' AND PROCESO = '0' AND CAMPO = '" & dr("CAMPO") & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using

                    End While
                End Using
            End Using

            MsgBox("Proceso terminado")

            Var25 = "SI"
            Me.Close()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

    End Sub

    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 4 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
            Else
                If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 4, CheckEnum.Unchecked)
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 4, state)
        Next
    End Sub
End Class