Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Input

Public Class frmCrearAlmacenes
    Private Sub frmCrearAlmacenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            barMenu.BackColor = Color.FromArgb(207, 221, 238)

        Catch ex As Exception
        End Try
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            Select Case Var10
                Case "INVE"
                    SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
                Case "GCINVER"
                    SQL = "SELECT * FROM GCALMACENESR" & Empresa & " ORDER BY CVE_ALM"
            End Select

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Do While dr.Read
                cboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
            Loop
            dr.Close()
            cboAlmacen.SelectedIndex = 0
        Catch ex As Exception
            Bitacora("0. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("0. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barGenerar_Click(sender As Object, e As EventArgs) Handles barGenerar.Click

        Try
            Dim CADENA As String
            Dim NUM_ALM As Integer

            If cboAlmacen.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione un almacen")
                Return
            End If

            CADENA = ""
            If tCVE_ART1.Text.Trim.Length > 0 And tCVE_ART2.Text.Trim.Length > 0 Then
                If tLINEA.Text.Trim.Length > 0 Then
                    CADENA = "WHERE CVE_ART >= '" & tCVE_ART1.Text & "' AND CVE_ART <= '" & tCVE_ART2.Text & "' AND LIN_PROD = '" & tLINEA.Text & "'"
                Else
                    CADENA = "WHERE CVE_ART >= '" & tCVE_ART1.Text & "' AND CVE_ART <= '" & tCVE_ART2.Text & "'"
                End If
            Else
                If tCVE_ART1.Text.Trim.Length > 0 Then
                    If tLINEA.Text.Trim.Length > 0 Then
                        CADENA = "WHERE CVE_ART >= '" & tCVE_ART1.Text & "' AND LIN_PROD = '" & tLINEA.Text & "'"
                    Else
                        CADENA = "WHERE CVE_ART >= '" & tCVE_ART1.Text & "'"
                    End If
                Else
                    If tCVE_ART2.Text.Trim.Length > 0 Then
                        If tLINEA.Text.Trim.Length > 0 Then
                            CADENA = "WHERE CVE_ART <= '" & tCVE_ART2.Text & "' AND LIN_PROD = '" & tLINEA.Text & "'"
                        Else
                            CADENA = "WHERE CVE_ART <= '" & tCVE_ART2.Text & "'"
                        End If
                    Else
                        If tLINEA.Text.Trim.Length > 0 Then
                            CADENA = "WHERE LIN_PROD = '" & tLINEA.Text & "'"
                        End If
                    End If
                End If
            End If

            Me.Cursor = Cursors.WaitCursor

            NUM_ALM = Val(cboAlmacen.Items(cboAlmacen.SelectedIndex).ToString.Substring(0, 2))
            Using cmd As SqlCommand = cnSAE.CreateCommand

                Dim cmd2 As New SqlCommand
                cmd2.Connection = cnSAE

                Select Case Var10
                    Case "INVE"
                        SQL = "SELECT CVE_ART FROM INVE" & Empresa & " " & CADENA
                    Case "GCINVER"
                        SQL = "SELECT CVE_ART FROM GCINVER " & CADENA
                End Select

                cmd.CommandText = SQL

                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        Select Case Var10
                            Case "INVE"
                                SQL = "IF NOT EXISTS (SELECT CVE_ART FROM MULT" & Empresa & " WHERE CVE_ART = '" & dr("CVE_ART") & "' AND CVE_ALM = " & NUM_ALM & ")
                                    INSERT INTO MULT" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, EXIST, STOCK_MIN, STOCK_MAX, COMP_X_REC, UUID,
                                    VERSION_SINC) VALUES('" & dr("CVE_ART") & "','" & NUM_ALM & "','A','','0', 0, 0, 0, NEWID(), GETDATE())"
                            Case "GCINVER"
                                SQL = "IF NOT EXISTS (SELECT CVE_ART FROM GCMULTR" & Empresa & " WHERE CVE_ART = '" & dr("CVE_ART") & "' AND CVE_ALM = " & NUM_ALM & ")
                                    INSERT INTO GCMULTR" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, EXIST, STOCK_MIN, STOCK_MAX, COMP_X_REC, UUID,
                                    VERSION_SINC) VALUES('" & dr("CVE_ART") & "','" & NUM_ALM & "','A','','0', 0, 0, 0, NEWID(), GETDATE())"
                            Case Else
                                SQL = "IF NOT EXISTS (SELECT CVE_ART FROM MULT" & Empresa & " WHERE CVE_ART = '" & dr("CVE_ART") & "' AND CVE_ALM = " & NUM_ALM & ")
                                    INSERT INTO MULT" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, EXIST, STOCK_MIN, STOCK_MAX, COMP_X_REC, UUID,
                                    VERSION_SINC) VALUES('" & dr("CVE_ART") & "','" & NUM_ALM & "','A','','0', 0, 0, 0, NEWID(), GETDATE())"
                        End Select

                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery.ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    End While
                End Using
            End Using
            Me.Cursor = Cursors.Default
            MsgBox("Proceso terminado")
            Me.Close()
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub frmCrearAlmacenes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub btnProd1_Click(sender As Object, e As EventArgs) Handles btnProd1.Click
        Try
            Select Case Var10
                Case "INVE"
                    Var2 = "InveR"
                Case "GCINVER"
                    Var2 = "GCINVER"
            End Select

            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ART1.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_ART2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub btnProd2_Click(sender As Object, e As EventArgs) Handles btnProd2.Click
        Try
            Select Case Var10
                Case "INVE"
                    Var2 = "InveR"
                Case "GCINVER"
                    Var2 = "GCINVER"
            End Select
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ART2.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                tLINEA.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_ART1_Validated(sender As Object, e As EventArgs) Handles tCVE_ART1.Validated
        Try
            If tCVE_ART1.Text.Trim.Length > 0 Then
                Dim DESCR As String

                Select Case Var10
                    Case "INVE"
                        DESCR = BUSCA_CAT("Inven", tCVE_ART1.Text)
                    Case "GCINVER"
                        DESCR = BUSCA_CAT("InvenR", tCVE_ART1.Text)
                    Case Else
                        DESCR = BUSCA_CAT("Inven", tCVE_ART1.Text)
                End Select

                If DESCR <> "" Then
                Else
                    MsgBox("Articulo inexistente")
                    tCVE_ART1.Text = ""
                    tCVE_ART1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_ART2_Validated(sender As Object, e As EventArgs) Handles tCVE_ART2.Validated
        Try
            If tCVE_ART2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Select Case Var10
                    Case "INVE"
                        DESCR = BUSCA_CAT("Inven", tCVE_ART2.Text)
                    Case "GCINVER"
                        DESCR = BUSCA_CAT("InvenR", tCVE_ART2.Text)
                    Case Else
                        DESCR = BUSCA_CAT("Inven", tCVE_ART2.Text)
                End Select
                If DESCR <> "" Then

                Else
                    MsgBox("Articulo inexistente")
                    tCVE_ART2.Text = ""
                    tCVE_ART2.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLINEA_Validated(sender As Object, e As EventArgs) Handles tLINEA.Validated
        Try
            If tLINEA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Linea", tLINEA.Text)
                If DESCR <> "" Then

                Else
                    MsgBox("Articulo inexistente")
                    tLINEA.Text = ""
                    tLINEA.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnLinea_Click(sender As Object, e As EventArgs) Handles btnLinea.Click
        Try
            Var2 = "Lineas"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tLINEA.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                cboAlmacen.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub frmCrearAlmacenes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
