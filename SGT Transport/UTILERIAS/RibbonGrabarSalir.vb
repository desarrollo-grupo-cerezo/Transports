Public Class RibbonGrabarSalir
    Private Sub RibbonForm4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim N = DateTime.Now.AddMonths(-1), d1 As String, d2 As String
        d1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        d2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        Try
            F1.Value = d1
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
            F1.Clear()
        Catch ex As Exception
        End Try
        Try
            F2.Value = d2
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"
            F2.Clear()
        Catch ex As Exception
        End Try


    End Sub

    Private Sub RibbonForm4_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub BtnArt1_Click(sender As Object, e As EventArgs) Handles BtnArt1.Click
        Try
            Var2 = "Articulo"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART1.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = ""
                TCVE_ART2.Focus()
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArt1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_ART1_Validated(sender As Object, e As EventArgs) Handles TCVE_ART1.Validated
        Try
            Dim DESCR As String
            If TCVE_ART1.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Inven", TCVE_ART1.Text)
                If DESCR = "" Then
                    MsgBox("Articulo inexistente")
                    TCVE_ART1.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnArt2_Click(sender As Object, e As EventArgs) Handles BtnArt2.Click
        Try
            Var2 = "Articulo"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART2.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArt2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_ART2_Validated(sender As Object, e As EventArgs) Handles TCVE_ART2.Validated
        Try
            Dim DESCR As String
            If TCVE_ART2.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Inven", TCVE_ART2.Text)
                If DESCR = "" Then
                    MsgBox("Articulo inexistente")
                    TCVE_ART2.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BTnCliente1_Click(sender As Object, e As EventArgs) Handles BTnCliente1.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE1.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_ART1.Select()
            Else
                TCLIENTE1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("79. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("79. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BTnCliente1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLIENTE1_Validated(sender As Object, e As EventArgs) Handles TCLIENTE1.Validated
        Try
            If TCLIENTE1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE1.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE1.Text.Trim.Length) & TCLIENTE1.Text.Trim
                    TCLIENTE1.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE1.Text)
                If DESCR <> "" Then

                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE1.Text = ""
                    TCLIENTE1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BTnCliente2_Click(sender As Object, e As EventArgs) Handles BTnCliente2.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE2.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_ART1.Select()
            End If
        Catch ex As Exception
            Bitacora("79. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("79. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BTnCliente1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCLIENTE2_Validated(sender As Object, e As EventArgs) Handles TCLIENTE2.Validated
        Try
            If TCLIENTE2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE2.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE2.Text.Trim.Length) & TCLIENTE2.Text.Trim
                    TCLIENTE2.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE2.Text)
                If DESCR <> "" Then

                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE2.Text = ""
                    TCVE_ART1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnProv1_Click(sender As Object, e As EventArgs) Handles btnProv1.Click

    End Sub

    Private Sub tCVE_PROV1_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV1.KeyDown

    End Sub

    Private Sub tCVE_PROV1_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV1.Validated

    End Sub

    Private Sub btnProv2_Click(sender As Object, e As EventArgs) Handles btnProv2.Click

    End Sub

    Private Sub TCVE_PROV2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PROV2.KeyDown

    End Sub

    Private Sub TCVE_PROV2_Validated(sender As Object, e As EventArgs) Handles TCVE_PROV2.Validated

    End Sub

    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click

    End Sub

    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown

    End Sub

    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated

    End Sub

    Private Sub C1Button2_Click(sender As Object, e As EventArgs) Handles BtnProd1.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var3 = "" : Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'TCVE_ART.Text = Var4
                'LtDescr.Text = Var5
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub C1Button3_Click(sender As Object, e As EventArgs) Handles BtnTractor.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TRACTOR.Text = Var5
                LtTractor.Text = Var6

                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUnidades_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles TCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtTractor.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_TRACTOR.Text = ""
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnProd2_Click(sender As Object, e As EventArgs) Handles BtnProd2.Click

    End Sub

    Private Sub BtnUnidades_Click_1(sender As Object, e As EventArgs) Handles BtnUnidades.Click

    End Sub
End Class