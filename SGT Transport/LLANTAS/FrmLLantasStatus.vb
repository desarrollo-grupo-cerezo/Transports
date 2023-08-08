Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmLLantasStatus
    Private ST_G As String = ""

    Private Sub FrmLLantasStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            tBox.Text = ""
            Lt1.Visible = False
            CboPilaStatus.Visible = False

            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_STATUS, DESCR FROM GCLLANTA_STATUS WHERE STATUS = 'A' ORDER BY CVE_STATUS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_STATUS") & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using
            ST_G = Var17
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 2) = Var17 Then
                    Fg.SetCellCheck(k, 1, CheckEnum.Checked)
                    If Fg(k, 2) = "6" Then
                        Lt1.Visible = True
                        CboPilaStatus.Visible = True
                    End If
                    Exit For
                End If
            Next
            If Var17 = "5" Then
                'tBox.Text = Var15
                'Lt1.Visible = True
                'tBox.Visible = True
            End If

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Clave", GetType(System.String))
            dt.Columns.Add("Descripcion", GetType(System.String))

            dt.Rows.Add("", "NO APLICA")
            CboPilaStatus.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_PILA, DESCR FROM GCPILADESECHO WHERE STATUS = 'A' ORDER BY CVE_PILA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CVE_PILA"), dr("DESCR"))
                    End While
                End Using
            End Using

            CboPilaStatus.TextDetached = True
            CboPilaStatus.ItemsDataSource = dt.DefaultView
            CboPilaStatus.ItemsDisplayMember = "Descripcion"
            CboPilaStatus.ItemsValueMember = "Clave"
            CboPilaStatus.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboPilaStatus.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            If Var18.Trim.Length > 0 Then
                For k = 1 To CboPilaStatus.Items.Count - 1
                    If CboPilaStatus.Items(k) = Var18 Then
                        CboPilaStatus.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            Bitacora("54. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("54. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmLLantasStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim CVE_ST As Integer = 0
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg.GetCellCheck(k, 1) = CheckEnum.Checked Then
                    CVE_ST = Fg(k, 2)
                End If
            Next
            If CVE_ST = 0 Then
                MsgBox("Por favor seleccione una opción")
                Return
            End If
            'If CVE_ST = 5 And tBox.Text.Trim.Length = 0 Then
            'MsgBox("Por favor la observación  de la llanta")
            'tBox.Focus()
            'Return
            'End If

        Catch ex As Exception
            Bitacora("54. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("54. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Dim OTRO As String

            Using cmd As SqlCommand = cnSAE.CreateCommand
                If CVE_ST = 5 Then
                    OTRO = tBox.Text.Trim
                Else
                    OTRO = ""
                End If

                Dim CVE_PILA As String

                CVE_PILA = CboPilaStatus.Items(CboPilaStatus.SelectedIndex)

                If CVE_PILA = "0" Then
                    CVE_PILA = ""
                End If

                SQL = "UPDATE GCLLANTAS SET STATUS_LLANTA = " & CVE_ST & ", LLANTA1 = '" & OTRO & "', CVE_PILA = '" & CVE_PILA & "'
                    WHERE CVE_LLANTA = '" & Var16 & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If

                Var13 = tBox.Text
                Var14 = CVE_ST

                Me.Close()
            End Using
            MsgBox("El estatus se grabo satisfactoriamente")
        Catch ex As Exception
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 Then
                If e.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row > 0 Then
                If e.Col = 1 Then
                    Lt1.Visible = False
                    tBox.Visible = False

                    Dim SelCheck As Boolean = False, Sigue As Boolean = True

                    For k = 1 To Fg.Rows.Count - 1
                        If Fg(k, 1) AndAlso Fg(k, 2) = "6" Then
                            Fg(k, 1) = False
                            Sigue = False
                        End If
                    Next

                    If Fg(Fg.Row, 2) <> "6" And Sigue Then
                        Select Case ST_G
                            Case "1"
                                MsgBox("Para cambiar el estatus debe eliminar la asignación de la llanta")
                                Fg.SetCellCheck(e.Row, 1, CheckEnum.Unchecked)
                                Return
                            Case Else
                        End Select
                        For k = 1 To Fg.Rows.Count - 1
                            If Fg(k, 1) And Fg(k, 2) = "1" Then
                                MsgBox("No se puede asignar este estatus, verifique asignación de llantas")
                                Fg.SetCellCheck(k, 1, CheckEnum.Unchecked)
                                SelCheck = True
                                Exit For
                            End If
                            If k <> Fg.Row Then
                                Fg(k, 1) = False
                            End If
                        Next
                    End If

                    If SelCheck Then
                        Return
                    Else
                        Fg.SetCellCheck(e.Row, 1, CheckEnum.Checked)

                        If Fg(Fg.Row, 2) = "6" Then
                            For k = 1 To Fg.Rows.Count - 1
                                If k <> Fg.Row Then
                                    Fg(k, 1) = False
                                End If
                            Next
                            Lt1.Visible = True
                            CboPilaStatus.Visible = True
                        Else
                            Lt1.Visible = False
                            CboPilaStatus.Visible = False
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
