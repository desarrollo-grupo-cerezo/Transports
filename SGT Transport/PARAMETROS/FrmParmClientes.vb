Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmParamClientes
    Private Sub FrmParmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TIPO As String = ""

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            Fg.Rows.Count = 1
            Fg.Cols(2).Visible = False
            Fg.Cols(6).Visible = False

            Fg.Cols(4).ComboList = "Caracter|Entero|Decimal|Texto"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CLIE_ADIC_C ORDER BY ORDEN"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("ORDEN") & vbTab & dr("NOMBRE") & vbTab & dr("LEYENDA") & vbTab & dr("TIPO") & vbTab &
                                   dr("LONGITUD") & vbTab & " ")
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCPARAMCLIENTES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        If dr.ReadNullAsEmptyInteger("CLIENTE_SECUENCIAL") = 0 Then
                            ChClaveCteSecuencial.Checked = False
                        Else
                            ChClaveCteSecuencial.Checked = True
                        End If
                        TSERIE_CLIENTE.Text = dr.ReadNullAsEmptyString("SERIE_CLIENTE")
                    End If
                End Using
            End Using


        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmParmClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Parámetros clientes")
        Me.Dispose()
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '(ORDEN SMALLINT Not NULL, NOMBRE VARCHAR(30) Not NULL, LEYENDA VARCHAR(50) NULL, TIPO VARCHAR(20) NULL, LONGITUD SMALLINT NULL, p
        Dim LEYENDA As String, TIPO As String = "", LONGITUD As String = "0", CAMPO As String

        Fg.FinishEditing()

        Try
            SQL = "UPDATE GCPARAMCLIENTES SET CLIENTE_SECUENCIAL = " & IIf(ChClaveCteSecuencial.Checked, 0, 1) & ", 
                  SERIE_CLIENTE = '" & TSERIE_CLIENTE.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    Else
                        SQL = "INSERTT INTO GCPARAMCLIENTES (CLIENTE_SECUENCIAL, SERIE_CLIENTE) VALUES (" &
                            IIf(ChClaveCteSecuencial.Checked, 1, 0) & ",'" & TSERIE_CLIENTE.Text & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            For k = 1 To Fg.Rows.Count - 1

                If Fg(k, 6) = "S" Then

                    CAMPO = "ADIC" & k
                    LEYENDA = Fg(k, 3)
                    If LEYENDA.Trim.Length = 0 Then LEYENDA = CAMPO

                    If Not IsNothing(Fg(k, 5)) Then
                        LONGITUD = Fg(k, 5)
                    Else
                        LONGITUD = "0"
                    End If

                    Select Case Fg(k, 4)
                        Case "Caracter"
                            TIPO = "VARCHAR"
                        Case "Entero"
                            TIPO = "INT"
                        Case "Decimal"
                            TIPO = "FLOAT"
                        Case "Texto"
                            TIPO = "VARCHAR"
                            LONGITUD = "MAX"
                    End Select
                    If IsNumeric(LONGITUD = "0") Then
                        If CInt(LONGITUD) = 0 Then
                            LONGITUD = "1"
                        End If
                    End If
                    Try
                        SQL = "INSERT INTO CLIE_ADIC_C (ORDEN, NOMBRE, LEYENDA, TIPO, LONGITUD)" &
                            " VALUES(ISNULL((SELECT MAX(ORDEN) + 1 FROM CLIE_ADIC_C),1), @NOMBRE, @LEYENDA, @TIPO, @LONGITUD)"

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = CAMPO.Trim
                            cmd.Parameters.Add("@LEYENDA", SqlDbType.VarChar).Value = LEYENDA
                            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = Fg(k, 4)
                            cmd.Parameters.Add("@LONGITUD", SqlDbType.VarChar).Value = LONGITUD
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    CREA_CAMPO("CLIE_ADIC", CAMPO, TIPO, LONGITUD, "")

                    Fg(k, 6) = " "
                Else
                    Try
                        CAMPO = "ADIC" & k
                        LEYENDA = Fg(k, 3)

                        SQL = "UPDATE CLIE_ADIC_C SET LEYENDA = @LEYENDA WHERE NOMBRE = @NOMBRE"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = CAMPO.Trim
                            cmd.Parameters.Add("@LEYENDA", SqlDbType.VarChar).Value = LEYENDA
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next

        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()

    End Sub
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            Fg.AddItem("" & vbTab & Fg.Rows.Count & vbTab & "" & vbTab & "ADIC" & Fg.Rows.Count & vbTab & "Caracter" & vbTab & "1" & vbTab & "S")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea eliminar el campo adicional?", vbYesNo) = vbNo Then
                    Return
                End If
                Try
                    If Fg(Fg.Row, 2).ToString.Trim.Length > 0 Then
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "ALTER TABLE CLIE_ADIC DROP COLUMN " & Fg(Fg.Row, 2)
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "DELETE FROM  CLIE_ADIC_C WHERE NOMBRE = '" & Fg(Fg.Row, 2) & "'"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Fg.RemoveItem(Fg.Row)
            End If
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles Fg.ComboCloseUp
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 4) = "Texto" Then
                    Fg(Fg.Row, 5) = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 5 Then
                    If Fg(Fg.Row, 4) = "Texto" Then
                        Fg.FinishEditing()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class