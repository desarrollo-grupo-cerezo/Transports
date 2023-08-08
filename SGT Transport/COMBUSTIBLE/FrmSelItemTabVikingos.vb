Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItemTabVikingos
    Private Sub FrmSelItemTabVikingos_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            Fg.Cols(1).AllowEditing = True

            TITULOS()
            'Var3 = TCVE_OPER.Text
            'Var4 = TCVE_UNI.Text
            Try
                If PASS_GRUPOCE.ToUpper = "BUS" Then
                    For k = 1 To Fg.Cols.Count - 1
                        Fg(0, k) = Fg(0, k) & " " & k
                    Next
                End If

            Catch ex As Exception
            End Try

            Try
                If Not IsNumeric(Var3) Then
                    Var3 = "0"
                End If
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT T.CVE_TAB, T.NUM_VIAJE, T.STATUS, T.FOLIO_LIQ, T.FECHA_IDA, T.CVE_OPER, T.CVE_UNI, T.NOMBRE_OPER, T.TIPO_VIAJE, T.CLIENTE, T.NOMBRE_CLIE, 
                        T.CVE_ORI, T.ORIGEN, T.CVE_DES, T.DESTINO, T.CARGADO_VACIO, T.KMS, T.RENDIMIENTO, T.LITROS, T.TONELADAS, ISNULL(T.CVE_RES,0) AS CVE_RESET
                        FROM GCTABULADOR_EXCEL T 
                        LEFT JOIN GCCLIE_OP C On C.CLAVE = T.CLIENTE 
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.CVE_ORI 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.CVE_DES 
                        WHERE ISNULL(T.STATUS,'A') = 'A' AND CVE_OPER = " & Convert.ToInt32(Var3) & " AND 
                        CVE_UNI = '" & Var4 & "' AND ISNULL(CVE_RES,0) = 0
                        ORDER BY T.CVE_TAB"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_TAB") & vbTab & dr("NUM_VIAJE") & vbTab & dr("FOLIO_LIQ") & vbTab &
                               dr("FECHA_IDA") & vbTab & dr("CVE_OPER") & vbTab & dr.ReadNullAsEmptyString("NOMBRE_OPER") & vbTab &
                               dr.ReadNullAsEmptyString("CVE_UNI") & vbTab & dr.ReadNullAsEmptyString("TIPO_VIAJE") & vbTab &
                               dr("CLIENTE") & vbTab & dr("NOMBRE_CLIE") & vbTab & dr("CVE_ORI") & vbTab & dr.ReadNullAsEmptyString("ORIGEN") & vbTab &
                               dr("CVE_DES") & vbTab & dr.ReadNullAsEmptyString("DESTINO") & vbTab &
                               IIf(dr.ReadNullAsEmptyInteger("CARGADO_VACIO") = 0, "Vacio", "Cargado") & vbTab &
                               dr("KMS") & vbTab & dr.ReadNullAsEmptyDecimal("RENDIMIENTO") & vbTab &
                               dr("LITROS") & vbTab & dr.ReadNullAsEmptyDecimal("TONELADAS"))

                        End While
                    End Using
                    Fg.AutoSizeCols()

                End Using
            Catch ex As Exception
                Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
            Fg.Redraw = True

            Fg.AutoSizeCols()

            Me.CenterToScreen()

            ReDim aDATA(0, 0)

            aDATA(0, 0) = ""

            Fg.Cols(2).Visible = False
            Fg.Cols(6).Visible = False
            Fg.Cols(9).Visible = False
            Fg.Cols(11).Visible = False
            Fg.Cols(13).Visible = False
            Fg.Cols(16).Visible = False
            Fg.Cols(17).Visible = False
            Fg.Cols(18).Visible = False
            Fg.Cols(19).Visible = False

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
    End Sub

    Private Sub FrmSelItemTabVikingos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Dim z As Integer = 0
        Try

            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 1) Then
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
                    If Fg(k, 1) Then
                        aDATA(z, 0) = Fg(k, 2)
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
        Me.Close()
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 2, state)
        Next
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
    Sub TITULOS()
        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 21

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150


            Fg(0, 1) = "Seleccione"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Boolean)

            Fg(0, 2) = "Clave"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Int32)

            Fg(0, 3) = "Num.viaje"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Int32)

            Fg(0, 4) = "Folio"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Int32)

            Fg(0, 5) = "Fecha"
            Dim cc4 As Column = Fg.Cols(5)
            cc4.DataType = GetType(Date)

            Fg(0, 6) = "Clave oper."
            Dim c5 As Column = Fg.Cols(6)
            c5.DataType = GetType(Int32)

            Fg(0, 7) = "Nombre operador"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(String)

            Fg(0, 8) = "Unidad"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(String)

            Fg(0, 9) = "Tipo viaje"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(String)

            Fg(0, 10) = "Cliente"
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(String)

            Fg(0, 11) = "Nombre cliente"
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(String)

            Fg(0, 12) = "Cve. origen"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(Int32)

            Fg(0, 13) = "Descripcion origen"
            Dim c12 As Column = Fg.Cols(13)
            c12.DataType = GetType(String)

            Fg(0, 14) = "Cve. destino"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(Int32)

            Fg(0, 15) = "Descripcion destino"
            Dim c14 As Column = Fg.Cols(15)
            c14.DataType = GetType(String)

            Fg(0, 16) = "Cargado/Vacio"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(String)

            Fg(0, 17) = "KMS"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Rendimiento"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 19) = "Litros"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"

            Fg(0, 20) = "Toneladas"
            Dim c19 As Column = Fg.Cols(20)
            c19.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"

        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
