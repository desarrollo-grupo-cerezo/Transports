Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmAlmacenesFAE
    Private Sub frmAlmacenesFAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        tDescr.MaxLength = 40

        cboAlmacen.Items.Clear()
        For k = 1 To 99
            cboAlmacen.Items.Add(k)
        Next

        If Var1 = "Nuevo" Then
            Try
                tDescr.Text = ""
                cboAlmacen.Enabled = True
                Try
                    For k = 1 To cboAlmacen.Items.Count - 1
                        If cboAlmacen.Items(k) = Var2 Then
                            cboAlmacen.SelectedIndex = k
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                End Try
                cboAlmacen.Focus()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT M.CVE_ALM, M.DESCR, CUEN_CONT FROM GCALMACENESF" & Empresa & " M WHERE CVE_ALM = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    For k = 0 To cboAlmacen.Items.Count - 1
                        If cboAlmacen.Items(k) = dr("CVE_ALM").ToString Then
                            cboAlmacen.SelectedIndex = k
                            Exit For
                        End If
                    Next
                    tDescr.Text = dr("DESCR").ToString
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                Else
                    cboAlmacen.SelectedIndex = -1
                    tDescr.Text = ""
                    tCUEN_CONT.Text = ""
                End If
                dr.Close()

                cboAlmacen.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmAlmacenesFAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmAlmacenesFAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        If cboAlmacen.SelectedIndex = -1 Then
            MsgBox("POr favor seleccione un almacen")
            Return
        End If


        cmd.CommandText = "UPDATE GCALMACENESF" & Empresa & " SET DESCR = @DESCR, CUEN_CONT = @CUEN_CONT 
            WHERE CVE_ALM = @CVE_ALM 
            IF @@ROWCOUNT = 0 
            INSERT INTO GCALMACENESF" & Empresa & " (CVE_ALM, DESCR, STATUS, CUEN_CONT, UUID, VERSION_SINC) VALUES(@CVE_ALM, @DESCR, 'A', 
            @CUEN_CONT, NEWID(), GETDATE())"
        Try
            cmd.Parameters.Add("@CVE_ALM", SqlDbType.Int).Value = CONVERTIR_TO_INT(cboAlmacen.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
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

    Private Sub frmAlmacenesFAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
