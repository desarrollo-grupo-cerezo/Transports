Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItemReseteoTab
    Private Sub FrmSelItemReseteoTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1

            SQL = "SELECT CVE_TAB, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                CASE ISNULL(CARGADO_VACIO,0) WHEN 0 THEN 'Vacio' ELSE 'Cargado' END AS CAR_VAC, ISNULL(TIPO_VIAJE,'') AS VIAJE, 
                CLIENTE, C.NOMBRE, ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As LTS, T.OBSER
                FROM GCTABULADOR_PAR T 
                LEFT JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                LEFT JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                ORDER BY CVE_TAB DESC"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & "" & vbTab & "" & vbTab & dr("NOMBRE") & vbTab & dr("DESCR_ORI") & vbTab &
                                   dr("DESCR_DES") & vbTab & dr("KM") & vbTab & dr("LTS") & vbTab & dr("VIAJE") & vbTab & dr("CAR_VAC") & vbTab &
                                   dr("CVE_ORI") & vbTab & dr("CVE_DES") & vbTab & dr("OBSER") & vbTab & dr("CLIENTE"))
                    End While
                End Using
            End Using

            Fg.AutoSizeCols()
            Fg.Redraw = True
            Me.CenterToScreen()

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmSelItemReseteoTab_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Dim z As Integer = 0
        Try

            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 2) Then
                        z += 1
                    End If
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            Fg.FinishEditing()

            Dim Ncap As Integer

            ReDim aDATA(z, z)
            z = 0
            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 2) Then
                        aDATA(z, 0) = Fg(k, 1)
                        Ncap = 1
                        Try
                            If IsNothing(Fg(k, 3)) Then
                                Ncap = 1
                            Else
                                If IsNumeric(Fg(k, 3)) Then
                                    Ncap = Fg(k, 3)
                                Else
                                    Ncap = 1
                                End If
                            End If
                        Catch ex As Exception
                            Ncap = 1
                        End Try
                        aDATA(z, 1) = Ncap
                        z += 1
                    End If
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            If z = 0 Then
                MsgBox("Por favor seleccione al menos un tabulador de ruta")
                Return
            End If

            Me.Close()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        ReDim aDOCS(-1)
        Me.Close()
    End Sub

    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 2, state)
        Next
    End Sub

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick

    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 3 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 2 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
            Else
                If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 2, CheckEnum.Unchecked)
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
