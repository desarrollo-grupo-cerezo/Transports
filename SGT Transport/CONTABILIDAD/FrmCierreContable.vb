Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmCierreContable
    Dim RUTA_MODELO As String = ""
    Private Sub FrmCierreContable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
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

            Select Case Var4
                Case "COMPRAS"
                    Me.Text = "Generar cierre contable Compras"
                Case "DEVOLUCION COMPRAS"
                    Me.Text = "Generar cierre contable Devolucion de compras"
                Case "FACTURAS"
                    Me.Text = "Generar cierre contable Facturas"
                Case "DEVOLUCION FACTURAS"
                    Me.Text = "Generar cierre contable Devolucion Facturas"
                Case "OT"
                    Me.Text = "Generar cierre contable Oredenes de trabajo"
                Case "INGRESO"
                    Me.Text = "Generar cierre contable Ingreso"
                Case "EGRESO"
                    Me.Text = "Generar cierre contable Egreso"
                Case "MOV LLANTAS"
                    Me.Text = "Generar cierre contable Movimientos llantas"
                Case "GASTOS"
                    Me.Text = "Generar cierre contable Gastos"
            End Select
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GET_RUTA_MODELO()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                RUTA_MODELO = dr("RUTA_MODELO").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCierreContable_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub

    Private Sub BarGenCierreContable_Click(sender As Object, e As ClickEventArgs) Handles BarGenCierreContable.Click

        If MsgBox("Realmente desea realizar el cierre contable en " & Var4 & "?", vbYesNo) = vbYes Then
            Try
                Select Case Var4
                    Case "COMPRAS"
                        Try
                            SQL = "UPDATE SET COMPC" & Empresa & " SET ACT_COI = 'S' WHERE 
                                FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    Case "DEVOLUCION COMPRAS"
                        Try
                            SQL = "UPDATE SET COMPD" & Empresa & " SET ACT_COI = 'S' WHERE 
                                FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    Case "FACTURAS"
                        Try
                            SQL = "UPDATE SET FACTF" & Empresa & " SET ACT_COI = 'S' WHERE 
                                FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    Case "DEVOLUCION FACTURAS"
                        Try
                            SQL = "UPDATE SET FACTD" & Empresa & " SET ACT_COI = 'S' WHERE 
                                FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    Case "OT"
                        Try
                            SQL = "UPDATE SET GCORDEN_TRABAJO_EXT SET ACT_COI = 'S' WHERE 
                                FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' "
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    Case "INGRESO"
                        Try
                            SQL = "UPDATE SET CUEN_DET" & Empresa & " SET AFEC_COI = 'A' WHERE 
                                FECHA_APLI >= '" & FSQL(F1.Value) & "' AND FECHA_APLI <= '" & FSQL(F2.Value) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    Case "EGRESO"
                        Try
                            SQL = "UPDATE SET PAGA_DET" & Empresa & " SET AFEC_COI = 'A' WHERE 
                                FECHA_APLI >= '" & FSQL(F1.Value) & "' AND FECHA_APLI <= '" & FSQL(F2.Value) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    Case "MOV LLANTAS"

                    Case "GASTOS"
                        Try
                            SQL = "UPDATE SET GCGASTOS SET ACT_COI = 'S' WHERE 
                                FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                    MsgBox("Proceso finalizado documentos procesados " & returnValue)
                                Else
                                    MsgBox("No fue posible actualizar documentos")
                                End If
                            End Using
                        Catch SQLex As SqlException
                            Dim SSS As SqlError, Sqlcadena As String = ""
                            For Each SSS In SQLex.Errors
                                Sqlcadena += SSS.Message & vbNewLine
                            Next
                            MsgBox(Sqlcadena)
                            BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                          SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                End Select
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
