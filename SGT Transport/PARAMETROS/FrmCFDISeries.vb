Imports System.Data.SqlClient
Public Class FrmCFDISeries
    Private Sub FrmCFDISeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.CenterToScreen()

            SQL = "SELECT ISNULL(SERIE,'') AS LETRA
                FROM FOLIOSF" & Empresa & "
                WHERE TIP_DOC = 'T' AND TIPO = 'D'"

            CboCPTraslado.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboCPTraslado.Items.Add(dr("LETRA"))
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(S.SERIE_CP_TRASLADO,'') AS SERIE_CP_TRAS, ISNULL(S.CVE_CLIE,'') AS CLIE, 
                    ISNULL(NOMBRE,'') AS NOMB
                    FROM CFDI_SERIES S
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = S.CVE_CLIE"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        For k = 0 To CboCPTraslado.Items.Count - 1
                            If CboCPTraslado.Items(k) = dr("SERIE_CP_TRAS") Then
                                CboCPTraslado.SelectedIndex = k
                                Exit For
                            End If
                        Next
                        TCVE_CLIE.Text = dr("CLIE")
                        L3.Text = dr("NOMB")
                    End While
                End Using
            End Using

        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub FrmCFDISeries_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        If CboCPTraslado.SelectedIndex = -1 Then
            MsgBox("por favor seleccione la serie")
            Return
        End If
        Try
            SQL = "IF EXISTS (SELECT SERIE_CP_TRASLADO FROM CFDI_SERIES)
                    UPDATE CFDI_SERIES SET SERIE_CP_TRASLADO = '" & CboCPTraslado.Text & "', CVE_CLIE = '" & TCVE_CLIE.Text & "'
                ELSE
                    INSERT INTO CFDI_SERIES (TIPO_DOC, SERIE_CP_TRASLADO, CVE_CLIE) VALUES('T','" & CboCPTraslado.Text & "','" &
                    TCVE_CLIE.Text & "')"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            MsgBox("Los datos se grabaron correctamente")

        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Close()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnClie_Click(sender As Object, e As EventArgs) Handles BtnClie.Click
        Try
            Var2 = "CLIE"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CLIE.Text = Var4
                L3.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If

        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CLIE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CLIE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnClie_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_CLIE_Validated(sender As Object, e As EventArgs) Handles TCVE_CLIE.Validated
        Try

            If TCVE_CLIE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_CLIE.Text.Trim) Then
                    DESCR = TCVE_CLIE.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_CLIE.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCVE_CLIE.Text)
                If DESCR <> "" Then
                    L3.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCVE_CLIE.Text = ""
                    TCVE_CLIE.Select()
                End If

            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


End Class