Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Themes

Public Class FrmFiltroReimpMasiva
    Private Sub FrmFiltroReimpMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()

        Catch ex As Exception
        End Try

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
    End Sub
    Private Sub FrmFiltroReimpMasiva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnClie1_Click(sender As Object, e As EventArgs) Handles BtnClie1.Click
        Try
            Var2 = "Clientes"
            Var3 = "" : Var4 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CLIE1.Text = Var4

                Var2 = "" : Var3 = "" : Var4 = ""
                TCVE_CLIE2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_CLIE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CLIE1.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnClie1_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_CLIE1_Validated(sender As Object, e As EventArgs) Handles TCVE_CLIE1.Validated
        Try
            If TCVE_CLIE1.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TCVE_CLIE1.Text.Trim) Then
                    DESCR = TCVE_CLIE1.Text.Trim
                    DESCR = Space(10 - Len(DESCR)) & DESCR
                    TCVE_CLIE1.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCVE_CLIE1.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Cliente inexistente")
                    TCVE_CLIE1.Text = ""
                    TCVE_CLIE1.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnClie2_Click(sender As Object, e As EventArgs) Handles BtnClie2.Click
        Try
            Var2 = "Clientes"
            Var3 = "" : Var4 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CLIE2.Text = Var4

                Var2 = "" : Var3 = "" : Var4 = ""
            End If
        Catch Ex As Exception
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_CLIE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CLIE2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnClie2_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_CLIE2_Validated(sender As Object, e As EventArgs) Handles TCVE_CLIE2.Validated
        Try
            If TCVE_CLIE2.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TCVE_CLIE2.Text.Trim) Then
                    DESCR = TCVE_CLIE2.Text.Trim
                    DESCR = Space(10 - Len(DESCR)) & DESCR
                    TCVE_CLIE2.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCVE_CLIE2.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Cliente inexistente")
                    TCVE_CLIE2.Text = ""
                    TCVE_CLIE2.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim CADENA_F As String, CADENA_CLIENTE As String, CADENA_FAC As String

        If TCVE_CLIE1.Text.Trim.Length > 0 And TCVE_CLIE2.Text.Trim.Length > 0 Then
            CADENA_CLIENTE = " AND CLIENTE >= '" & TCVE_CLIE1.Text & "' AND CLIENTE <= '" & TCVE_CLIE2.Text & "'"
        Else
            If TCVE_CLIE1.Text.Trim.Length > 0 And TCVE_CLIE2.Text.Trim.Length = 0 Then
                CADENA_CLIENTE = " AND CLIENTE >= '" & TCVE_CLIE1.Text & "'"
            Else
                If TCVE_CLIE2.Text.Trim.Length > 0 Then
                    CADENA_CLIENTE = " AND CLIENTE <= '" & TCVE_CLIE2.Text & "'"
                Else
                    CADENA_CLIENTE = ""
                End If
            End If
        End If
        If TFAC1.Text.Trim.Length > 0 And TFAC2.Text.Trim.Length > 0 Then
            CADENA_FAC = " AND FACTURA >= '" & TFAC1.Text & "' AND FACTURA <= '" & TFAC2.Text & "'"
        Else
            If TFAC1.Text.Trim.Length > 0 And TFAC2.Text.Trim.Length = 0 Then
                CADENA_FAC = " AND FACTURA >= '" & TFAC1.Text & "'"
            Else
                If TFAC2.Text.Trim.Length > 0 Then
                    CADENA_FAC = " AND FACTURA <= '" & TFAC2.Text & "'"
                Else
                    CADENA_FAC = ""
                End If
            End If
        End If
        If ChIgnorarFechas.Checked Then
            CADENA_F = ""
        Else
            CADENA_F = " AND FECHAELAB >= '" & FSQL(F1.Value) & " 00:00:00' AND FECHAELAB <= '" & FSQL(F2.Value) & " 23:59:00'"
        End If

        Try
            Dim ImpresoraPre As String

            ImpresoraPre = PrintDialog1.PrinterSettings.PrinterName
            If PrintDialog1.ShowDialog() = DialogResult.OK Then

                If SetDefaulPrinter(PrintDialog1.PrinterSettings.PrinterName) Then
                End If

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT FACTURA
                      FROM CFDI 
                      WHERE TIMBRADO = 'S' AND ISNULL(ESTATUS,'') <> 'C' " &
                      CADENA_CLIENTE & CADENA_FAC & CADENA_F & "
                      ORDER BY FECHAELAB"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Try
                                IMPRIMIR_CFDI(dr("FACTURA"), "CARTA PORTE BUENO", 999)

                                Dim MyProcess As New Process
                                MyProcess.StartInfo.CreateNoWindow = False
                                MyProcess.StartInfo.Verb = "print"
                                MyProcess.StartInfo.FileName = FILE_PDF
                                MyProcess.Start()
                                MyProcess.WaitForExit(10000)
                                Try
                                    MyProcess.CloseMainWindow()
                                    MyProcess.Close()
                                Catch ex As Exception
                                    Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Catch ex As Exception
                                Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While
                    End Using
                End Using
                If SetDefaulPrinter(ImpresoraPre) Then
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BrtFactura1_Click(sender As Object, e As EventArgs) Handles BrtFactura1.Click
        Try
            Var2 = "FAC CFDI"
            Var3 = "" : Var4 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TFAC1.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = ""
            End If
        Catch Ex As Exception
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TFAC1_KeyDown(sender As Object, e As KeyEventArgs) Handles TFAC1.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BrtFactura1_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TFAC1_Validated(sender As Object, e As EventArgs) Handles TFAC1.Validated
        Try
            If TFAC1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("FAC CFDI", TFAC1.Text.Trim)
                If DESCR <> "" Then
                Else
                    MsgBox("Factura inexistente")
                    TFAC1.Text = ""
                    TFAC1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BrtFactura2_Click(sender As Object, e As EventArgs) Handles BrtFactura2.Click
        Try
            Var2 = "FAC CFDI"
            Var3 = "" : Var4 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TFAC2.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = ""
            End If
        Catch Ex As Exception
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TFAC2_KeyDown(sender As Object, e As KeyEventArgs) Handles TFAC2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BrtFactura2_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TFAC2_Validated(sender As Object, e As EventArgs) Handles TFAC2.Validated
        Try
            If TFAC2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("FAC CFDI", TFAC2.Text.Trim)
                If DESCR <> "" Then
                Else
                    MsgBox("Factura inexistente")
                    TFAC2.Text = ""
                    TFAC2.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class