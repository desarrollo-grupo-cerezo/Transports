Imports C1.Win.C1Themes
Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class FrmMultiAlmacenFAlta
    Private Sub frmMultiAlmacenFAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            cboAlmacen.Items.Clear()
            Do While dr.Read
                cboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
            Loop
            dr.Close()
            cboAlmacen.SelectedIndex = 0
        Catch ex As Exception
            Bitacora("0. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("0. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        tCVE_ART.Text = ""
        tCTRL_ALM.Text = ""
        tEXIST.Value = 0
        tSTOCK_MIN.Value = 0
        tSTOCK_MAX.Value = 0
        tCOMP_X_REC.Value = 0


        If Var1 = "Nuevo" Then
            Try
                tCVE_ART.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT M.CVE_ART, ISNULL(M.CVE_ALM,1) AS ALM, M.STATUS, M.CTRL_ALM, M.EXIST, M.STOCK_MIN, M.STOCK_MAX, M.COMP_X_REC " &
                    "FROM GCMULTF" & Empresa & " M WHERE CVE_ART = '" & Var2 & "' AND CVE_ALM = " & Var3
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_ART.Text = dr("CVE_ART").ToString
                    For k = 1 To cboAlmacen.Items.Count - 1
                        If CInt(cboAlmacen.Items(k).ToString.Substring(0, 2)) = dr("ALM").ToString Then
                            cboAlmacen.SelectedIndex = k
                            Exit For
                        End If
                    Next
                    tCTRL_ALM.Text = dr("CTRL_ALM").ToString
                    tEXIST.Value = dr("EXIST").ToString
                    tSTOCK_MIN.Value = dr("STOCK_MIN").ToString
                    tSTOCK_MAX.Value = dr("STOCK_MAX").ToString
                    tCOMP_X_REC.Value = dr("COMP_X_REC").ToString
                End If
                dr.Close()
                tCVE_ART.Enabled = False
                btnProd.Enabled = False
                cboAlmacen.Enabled = False

                tCTRL_ALM.Select()

            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmMultiAlmacenFAlta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub frmMultiAlmacenFAlta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmMultiAlmacenFAlta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim CVE_ALM As Integer

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tCVE_ART.Text.Trim.Length = 0 Then
            MsgBox("La clave del articulo no debe quedar vacia, verifique por favor")
            Return
        End If

        If cboAlmacen.SelectedIndex = 1 Then
            MsgBox("Por favor seleccione un almacen")
            Return
        End If
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("InveR", tCVE_ART.Text)
            If DESCR <> "N" Then
            Else
                MsgBox("La clave del artículo no existe en el catálogo")
                tCVE_ART.SelectAll()
                tCVE_ART.Select()
                Return
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CVE_ALM = cboAlmacen.Text.Substring(0, 2)

        SQL = "UPDATE GCMULTF" & Empresa & " SET CTRL_ALM = @CTRL_ALM, STOCK_MIN = @STOCK_MIN, " &
            "STOCK_MAX = @STOCK_MAX, COMP_X_REC = @COMP_X_REC " &
            "WHERE CVE_ART = @CVE_ART AND CVE_ALM = @CVE_ALM " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCMULTF" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, EXIST, STOCK_MIN, STOCK_MAX, COMP_X_REC, UUID, VERSION_SINC) " &
            "VALUES(@CVE_ART, @CVE_ALM, 'A', @CTRL_ALM, '0', @STOCK_MIN, @STOCK_MAX, @COMP_X_REC, NEWID(), GETDATE())"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(tCVE_ART.Text)
            cmd.Parameters.Add("@CVE_ALM", SqlDbType.Int).Value = CONVERTIR_TO_INT(CVE_ALM)
            cmd.Parameters.Add("@CTRL_ALM", SqlDbType.VarChar).Value = tCTRL_ALM.Text
            cmd.Parameters.Add("@STOCK_MIN", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tSTOCK_MIN.Text)
            cmd.Parameters.Add("@STOCK_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tSTOCK_MAX.Text)
            cmd.Parameters.Add("@COMP_X_REC", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCOMP_X_REC.Text)
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub tCVE_ART_Validating(sender As Object, e As CancelEventArgs) Handles tCVE_ART.Validating
        Try
            If tCVE_ART.Text.Trim.Length = 0 Then
                tCVE_ART.Select()
                e.Cancel = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnProd_Click(sender As Object, e As EventArgs) Handles btnProd.Click
        Try
            Var2 = "InveR"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ART.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                cboAlmacen.Focus()
            End If
        Catch ex As Exception
            MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnProd_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_ART_Validated(sender As Object, e As EventArgs) Handles tCVE_ART.Validated
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("InveR", tCVE_ART.Text)
            If DESCR <> "N" Then
            Else
                MsgBox("La clave del artículo no existe en el catálogo")
                tCVE_ART.SelectAll()
                tCVE_ART.Select()
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
