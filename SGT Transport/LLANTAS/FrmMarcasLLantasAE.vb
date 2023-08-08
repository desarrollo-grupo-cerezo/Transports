Imports System.Data.SqlClient
Public Class FrmMarcasLLantasAE
    Private Sub FrmMarcasLLantasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        C1SuperTooltip1.SetToolTip(BarGrabar, "F2 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                TClave.Text = GET_MAX("GCMARCAS", "CVE_MARCA")
                TClave.Enabled = False
                TDescr.Text = ""
                TDescr.Focus()
            Catch ex As Exception
                MsgBox("4. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT M.CVE_MARCA, ISNULL(M.TIPO, '') AS TIP, M.DESCR, ISNULL(T.DESCR,'') AS DESCR_TIPO " &
                    "FROM GCMARCAS M " &
                    "LEFT JOIN GCLLANTA_TIPO T ON T.CVE_TIPO = M.TIPO " &
                    "WHERE M.CVE_MARCA = '" & Var2 & "' AND M.STATUS = 'A'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TClave.Text = dr("CVE_MARCA")
                    TDescr.Text = dr("DESCR")
                    TTipo.Text = dr("TIP")
                    Lt.Text = dr("DESCR_TIPO")
                Else
                    TDescr.Text = "" : TTipo.Text = "" : Lt.Text = ""
                End If
                dr.Close()
                TClave.Enabled = False
                TDescr.Focus()

            Catch ex As Exception
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmMarcasLLantasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmMarcasLLantasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCMARCAS SET CVE_MARCA = @CVE_MARCA, DESCR = @DESCR, TIPO = @TIPO " &
            " WHERE CVE_MARCA = @CVE_MARCA " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCMARCAS (CVE_MARCA, STATUS, DESCR, TIPO)  VALUES(@CVE_MARCA, 'A', @DESCR, @TIPO)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_MARCA", SqlDbType.VarChar).Value = TClave.Text

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDescr.Text
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TTipo.Text
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
            MsgBox("8. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Bitacora("5. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTipo_Click(sender As Object, e As EventArgs) Handles BtnTipo.Click
        Try
            Var2 = "MarcaTipo"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()

            TTipo.Text = Var4
            Lt.Text = Var5

            Var2 = ""
            Var4 = ""
            Var5 = ""
        Catch ex As Exception
            MsgBox("6. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("6. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles TTipo.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTipo_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TTipo_Validated(sender As Object, e As EventArgs) Handles TTipo.Validated
        Try
            If TTipo.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo Unidad", TTipo.Text)
                If DESCR <> "" Then
                    Lt.Text = DESCR
                Else
                    MsgBox("Puesto inexistente")
                    TTipo.Text = ""
                    TTipo.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("25. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
