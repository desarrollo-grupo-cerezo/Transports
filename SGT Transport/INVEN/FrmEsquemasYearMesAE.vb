Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar

Public Class FrmEsquemasYearMesAE
    Private Sub FrmEsquemasYearMesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)
        Catch ex As Exception
        End Try

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        lbClave.Text = Var4

        If Var1 = "Nuevo" Then

        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE
                If Var4 = "Año" Then
                    SQL = "SELECT NUM_IMPU, [YEAR], IMPUESTO = CASE NUM_IMPU WHEN 3 THEN 'RET. IVA' WHEN 4 THEN 'IVA' END, CUENTA FROM CTAYEAR WHERE NUM_IMPU = " & Var2 & " AND [YEAR] = " & Var3
                Else
                    SQL = "SET LANGUAGE Spanish
                           SELECT NUM_IMPU, MES, MES_NOMBRE = UPPER(DATENAME (MONTH, CONCAT('1900', RIGHT(CONCAT('0', MES), 2) ,'01'))), IMPUESTO = CASE NUM_IMPU WHEN 3 THEN 'RET. IVA' WHEN 4 THEN 'IVA' END, CUENTA FROM CTAMES WHERE NUM_IMPU = " & Var2 & " AND MES = " & Var3
                End If

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    If Var4 = "Año" Then
                        txYearMes.Tag = dr("YEAR").ToString
                        txYearMes.Text = dr("YEAR").ToString
                        txImpuesto.Tag = dr("NUM_IMPU").ToString
                        txImpuesto.Text = dr("IMPUESTO").ToString
                        txCuenta.Text = dr("CUENTA").ToString
                    Else
                        txYearMes.Tag = dr("MES").ToString
                        txYearMes.Text = dr("MES_NOMBRE").ToString
                        txImpuesto.Tag = dr("NUM_IMPU").ToString
                        txImpuesto.Text = dr("IMPUESTO").ToString
                        txCuenta.Text = dr("CUENTA").ToString
                    End If
                Else
                    txYearMes.Tag = "0"
                    txYearMes.Text = ""
                    txImpuesto.Tag = "0"
                    txImpuesto.Text = ""
                    txCuenta.Text = ""

                End If
                dr.Close()

                txCuenta.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmLIenasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmLIenasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE


        If txYearMes.Text.Trim.Length = 0 Then
            MsgBox("La clave no debe quedar vacia, verifique por favor")
            Return
        End If

        If Var4 = "Año" Then
            SQL = "UPDATE CTAYEAR SET CUENTA = @CUENTA WHERE NUM_IMPU = @NUMIMPU AND [YEAR] = @YEARMES"
        Else
            SQL = "UPDATE CTAMES SET CUENTA = @CUENTA WHERE NUM_IMPU = @NUMIMPU AND MES = @YEARMES"
        End If


        Try
            cmd.CommandText = SQL
            cmd.Parameters.Add("@YEARMES", SqlDbType.Int).Value = txYearMes.Tag
            cmd.Parameters.Add("@NUMIMPU", SqlDbType.Int).Value = txImpuesto.Tag
            cmd.Parameters.Add("@CUENTA", SqlDbType.VarChar).Value = txCuenta.Text


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
