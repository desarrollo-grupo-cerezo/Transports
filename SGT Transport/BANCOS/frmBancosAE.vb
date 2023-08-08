Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmBancosAE
    Private Sub frmBancosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(MnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        tCVE_BANCO.Text = ""
        tDescr.Text = ""
        tRFC.Text = ""
        tCalle.Text = ""
        tCiudad.Text = ""
        tCiudad.Text = ""
        tCorreo.Text = ""
        tCTA_BANCARIA.Text = ""
        tCLABE.Text = ""
        tEJECUTIVO.Text = ""
        tALIAS.Text = ""
        tSUCURSAL.Text = ""
        tSALDO.Text = ""

        If Var1 = "Nuevo" Then
            Try
                tCVE_BANCO.Text = GET_MAX("GCBANCOS", "CVE_BANCO")
                tCVE_BANCO.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT B.CVE_BANCO, B.STATUS, B.DESCR, B.CALLE, B.TELEFONO, B.CIUDAD, B.CORREO1, B.RFC, B.CTA_BANCARIA, " &
                    "B.CLABE, B.FECHA_APER, B.EJECUTIVO, B.ALIAS, B.SUCURSAL, B.SALDO " &
                    "FROM GCBANCOS B WHERE CVE_BANCO = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_BANCO.Text = dr("CVE_BANCO")
                    tDescr.Text = dr("DESCR")
                    tRFC.Text = dr("RFC")
                    tCalle.Text = dr("CALLE").ToString
                    tTelefono.Text = dr("TELEFONO").ToString
                    tCiudad.Text = dr("CIUDAD").ToString
                    tCorreo.Text = dr("CORREO1").ToString

                    tCTA_BANCARIA.Text = dr("CTA_BANCARIA").ToString
                    tCLABE.Text = dr("CLABE").ToString
                    If IsDate(dr("FECHA_APER").ToString) Then
                        F1.Value = dr("FECHA_APER").ToString
                    Else
                        F1.Value = Date.Today
                    End If

                    tEJECUTIVO.Text = dr("EJECUTIVO").ToString
                    tALIAS.Text = dr("ALIAS").ToString
                    tSUCURSAL.Text = dr("SUCURSAL").ToString
                    tSALDO.Text = dr("SALDO").ToString
                End If
                dr.Close()

                tCVE_BANCO.Enabled = False
                If CONVERTIR_TO_DECIMAL(tSALDO.Text) > 0 Then
                    tSALDO.Enabled = False
                End If
                tDescr.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmBancosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmBancosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCBANCOS SET DESCR = @DESCR, CALLE = @CALLE, TELEFONO = @TELEFONO, CIUDAD = @CIUDAD, " &
            "SALDO = @SALDO, CORREO1 = @CORREO1, RFC = @RFC, CTA_BANCARIA = @CTA_BANCARIA, " &
            "CLABE = @CLABE, FECHA_APER = @FECHA_APER, EJECUTIVO = @EJECUTIVO, ALIAS = @ALIAS, SUCURSAL = @SUCURSAL " &
            "WHERE CVE_BANCO = @CVE_BANCO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCBANCOS (CVE_BANCO, STATUS, DESCR, CALLE, TELEFONO, CIUDAD, SALDO, CORREO1, RFC, CTA_BANCARIA, " &
            "CLABE, FECHA_APER, EJECUTIVO, ALIAS, SUCURSAL) VALUES(@CVE_BANCO, 'A', @DESCR, @CALLE, @TELEFONO, @CIUDAD, " &
            "@SALDO, @CORREO1, @RFC, @CTA_BANCARIA, @CLABE, @FECHA_APER, @EJECUTIVO, @ALIAS, @SUCURSAL)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_BANCO", SqlDbType.VarChar).Value = tCVE_BANCO.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar, 90).Value = tDescr.Text
            cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = tCalle.Text
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = tTelefono.Text
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = tCiudad.Text
            cmd.Parameters.Add("@CORREO1", SqlDbType.VarChar).Value = tCorreo.Text
            cmd.Parameters.Add("@SALDO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tSALDO.Text)
            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = tRFC.Text
            cmd.Parameters.Add("@CTA_BANCARIA", SqlDbType.VarChar).Value = tCTA_BANCARIA.Text
            cmd.Parameters.Add("@CLABE", SqlDbType.VarChar).Value = tCLABE.Text
            cmd.Parameters.Add("@FECHA_APER", SqlDbType.DateTime).Value = F1.Value
            cmd.Parameters.Add("@EJECUTIVO", SqlDbType.VarChar).Value = tEJECUTIVO.Text
            cmd.Parameters.Add("@ALIAS", SqlDbType.VarChar).Value = tALIAS.Text
            cmd.Parameters.Add("@SUCURSAL", SqlDbType.VarChar).Value = tSUCURSAL.Text

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
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmBancosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
