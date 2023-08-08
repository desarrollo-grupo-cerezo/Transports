Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar

Public Class FrmFoliosfAE
    Private TIP_DOC As String
    Private Sub frmFoliosfAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Me.CenterToScreen()
        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        Me.KeyPreview = True
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

        TIP_DOC = Var5
        tTIP_DOC.Text = ""
        tFOLIODESDE.Text = ""
        tFOLIOHASTA.Text = ""
        tSERIE.Text = ""
        tULT_DOC.Text = ""

        CboTipo.Items.Add("Impresión")
        CboTipo.Items.Add("Digital")

        If Var1 = "Nuevo" Then
            Try
                tSERIE.Enabled = True
                tTIP_DOC.Text = TIP_DOC
                tSERIE.Text = Var6
                CboTipo.SelectedIndex = 0
                tFOLIODESDE.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT L.TIP_DOC, L.TIPO, L.FOLIODESDE, L.FOLIOHASTA, L.SERIE, L.ULT_DOC, L.FECH_ULT_DOC, L.STATUS
                    FROM FOLIOSF" & Empresa & " L 
                    WHERE TIP_DOC = '" & TIP_DOC & "' AND SERIE = '" & Var6 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tTIP_DOC.Text = dr("TIP_DOC").ToString
                    tFOLIODESDE.Text = dr("FOLIODESDE").ToString
                    tFOLIOHASTA.Text = dr("FOLIOHASTA").ToString
                    tSERIE.Text = dr("SERIE").ToString
                    tULT_DOC.Text = dr("ULT_DOC").ToString
                    If dr.ReadNullAsEmptyString("TIPO") = "I" Then
                        CboTipo.SelectedIndex = 0
                    Else
                        CboTipo.SelectedIndex = 1
                    End If
                End If
                dr.Close()

                tTIP_DOC.Enabled = False
                tSERIE.Enabled = False
                tFOLIODESDE.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmFoliosfAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmFoliosfAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmFoliosfAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        If IsNothing(TIP_DOC) Then
            MsgBox("Por favor seleccione el tipo de documento")
            Me.Close()
            Return
        End If

        SQL = "UPDATE FOLIOSF" & Empresa & " SET FOLIODESDE = @FOLIODESDE, FOLIOHASTA = @FOLIOHASTA, ULT_DOC = @ULT_DOC, TIPO = @TIPO
            WHERE TIP_DOC = @TIP_DOC AND SERIE = @SERIE
            IF @@ROWCOUNT = 0
            INSERT INTO FOLIOSF" & Empresa & " (TIP_DOC, TIPO, FOLIODESDE, FOLIOHASTA, SERIE, ULT_DOC, FECH_ULT_DOC, STATUS)
            VALUES(@TIP_DOC, @TIPO, @FOLIODESDE, @FOLIOHASTA, @SERIE, @ULT_DOC, GETDATE(), 'D')"

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = TIP_DOC
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = IIf(CboTipo.SelectedIndex = 0, "I", "D")
            cmd.Parameters.Add("@FOLIODESDE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tFOLIODESDE.Text)
            cmd.Parameters.Add("@FOLIOHASTA", SqlDbType.Int).Value = CONVERTIR_TO_INT(tFOLIOHASTA.Text)
            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = tSERIE.Text
            cmd.Parameters.Add("@ULT_DOC", SqlDbType.Int).Value = CONVERTIR_TO_INT(tULT_DOC.Text)
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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
