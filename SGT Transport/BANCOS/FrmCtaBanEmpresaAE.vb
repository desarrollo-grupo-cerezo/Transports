
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmCtaBanEmpresaAE
    Private Sub FrmCtaBanEmpresaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.KeyPreview = True
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                Dim z As Integer

                SQL = "SELECT * FROM GCBANCOS WHERE STATUS = 'A' ORDER BY DESCR"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    z = 0
                    CboBanco.Items.Clear()
                    Do While dr.Read
                        CboBanco.Items.Add(New ValueDescriptionPair(dr("CVE_BANCO"), dr("DESCR"), dr("CVE_BANCO"), "", z))
                        z = z + 1
                    Loop
                    dr.Close()
                    CboBanco.SelectedIndex = -1
                End Using
            End Using
        Catch ex As Exception
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED 
                    FROM MONED" & Empresa & " WHERE STATUS = 'A' ORDER BY NUM_MONED"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboMoneda.Items.Add(dr("NUM_MONED") & " " & dr("DESCR"))
                    End While
                End Using
                CboMoneda.SelectedIndex = 0
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        TSALDO.Value = 0

        If Var1 = "Nuevo" Then
            Try
                TCVE_BANCO.Text = GET_MAX_TRY("CUENTA_BENEF" & Empresa, "CLAVE")
                TCVE_BANCO.Enabled = False
                TCTA_BANCARIA.Text = ""
                TCTA_BANCARIA.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            If Var1 = "XXX" Then
                TCTA_BANCARIA.Select()
            Else
                BUSCA_CTA()
                TCVE_BANCO.Enabled = False
                TCTA_BANCARIA.Select()
            End If
        End If
    End Sub
    Sub BUSCA_CTA()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT B.CLAVE, B.STATUS, B.NOMBRE_BANCO, B.CALLE, B.TELEFONO, B.CIUDAD, B.CORREO1, B.RFC_BANCO, 
                B.CUENTA_BANCARIA, B.CLABE, B.FECHA_APER, B.EJECUTIVO, B.ALIAS, B.SUCURSAL, ISNULL(B.SALDO,0) AS SALD, 
                ISNULL(B.NUM_MONED,0) AS CVE_MONED, ISNULL(M.DESCR,'') AS DES, B.CUENTA_CONTABLE_FINANCIERA, B.CUENTA_CONTABLE_FISCAL, B.CUENTA_CONTABLE_FISCAL_EG, ISNULL(B.CVE_BANCO, 0) AS CVE_BANCO
                FROM CUENTA_BENEF" & Empresa & " B 
                LEFT JOIN MONED" & Empresa & " M ON M.NUM_MONED = B.NUM_MONED
                WHERE CLAVE = '" & Var2 & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then

                Try
                    For Each vdp As ValueDescriptionPair In CboBanco.Items
                        If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_BANCO") Then
                            CboBanco.SelectedIndex = vdp.cboIndex
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                TCTA_BANCARIA.Text = dr("CUENTA_BANCARIA").ToString
                TRFC.Text = dr("RFC_BANCO").ToString
                TNOMBRE.Text = dr("NOMBRE_BANCO").ToString
                TCVE_BANCO.Text = dr("CLAVE").ToString
                TCalle.Text = dr("CALLE").ToString
                TTelefono.Text = dr("TELEFONO").ToString
                TCiudad.Text = dr("CIUDAD").ToString
                TCorreo.Text = dr("CORREO1").ToString
                CCFINANCIERA.Text = dr("CUENTA_CONTABLE_FINANCIERA").ToString
                CCFISCAL.Text = dr("CUENTA_CONTABLE_FISCAL").ToString
                CCFISCAL_EGRESOS.Text = dr("CUENTA_CONTABLE_FISCAL_EG").ToString

                TCLABE.Text = dr("CLABE").ToString
                If IsDate(dr("FECHA_APER").ToString) Then
                    F1.Value = dr("FECHA_APER").ToString
                Else
                    F1.Value = Date.Today
                End If

                TEJECUTIVO.Text = dr("EJECUTIVO").ToString
                TALIAS.Text = dr("ALIAS").ToString
                TSUCURSAL.Text = dr("SUCURSAL").ToString
                TSALDO.Text = dr("SALD").ToString
                If dr("CVE_MONED") > 0 Then
                    For k = 0 To CboMoneda.Items.Count - 1
                        If CboMoneda.Items(k).ToString.Substring(0, 2).Trim = dr("CVE_MONED") Then
                            CboMoneda.SelectedIndex = k
                            Exit For
                        End If
                    Next
                End If

            Else
                TCTA_BANCARIA.Text = ""
                TRFC.Text = ""
                TNOMBRE.Text = ""
                TCVE_BANCO.Text = ""
                TSALDO.Value = 0
            End If


            dr.Close()
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCtaBanEmpresaAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim CVE_BANCO As Integer

        SQL = "UPDATE CUENTA_BENEF" & Empresa & " SET NOMBRE_BANCO = @NOMBRE_BANCO, CALLE = @CALLE, TELEFONO = @TELEFONO, 
            CIUDAD = @CIUDAD, SALDO = @SALDO, CORREO1 = @CORREO1, RFC_BANCO = @RFC_BANCO, CUENTA_BANCARIA = @CUENTA_BANCARIA,
            CLABE = @CLABE, FECHA_APER = @FECHA_APER, EJECUTIVO = @EJECUTIVO, ALIAS = @ALIAS, SUCURSAL = @SUCURSAL,
            NUM_MONED = @NUM_MONED, CUENTA_CONTABLE_FINANCIERA=@CUENTA_CONTABLE_FINANCIERA, CUENTA_CONTABLE_FISCAL=@CUENTA_CONTABLE_FISCAL,
            CUENTA_CONTABLE_FISCAL_EG=@CUENTA_CONTABLE_FISCAL_EG, CVE_BANCO=@CVE_BANCO
            WHERE CLAVE = @CLAVE
            IF @@ROWCOUNT = 0
            INSERT INTO CUENTA_BENEF" & Empresa & " (CLAVE, STATUS, NOMBRE_BANCO, CALLE, TELEFONO, CIUDAD, SALDO, CORREO1, 
            RFC_BANCO, CUENTA_BANCARIA, CLABE, FECHA_APER, EJECUTIVO, ALIAS, SUCURSAL, CUENTA_CONTABLE_FINANCIERA, CUENTA_CONTABLE_FISCAL, CUENTA_CONTABLE_FISCAL_EG, CVE_BANCO) 
            VALUES 
            (@CLAVE, 'A', @NOMBRE_BANCO, @CALLE, @TELEFONO, @CIUDAD, @SALDO, @CORREO1, @RFC_BANCO, @CUENTA_BANCARIA, @CLABE, 
            @FECHA_APER, @EJECUTIVO, @ALIAS, @SUCURSAL, @CUENTA_CONTABLE_FINANCIERA, @CUENTA_CONTABLE_FISCAL, @CUENTA_CONTABLE_FISCAL_EG, @CVE_BANCO)"

        Try

            Try
                If CboBanco.SelectedIndex = -1 Then
                    CVE_BANCO = 0
                Else
                    CVE_BANCO = CType(CboBanco.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCVE_BANCO.Text
                cmd.Parameters.Add("@CUENTA_BANCARIA", SqlDbType.VarChar).Value = TCTA_BANCARIA.Text
                cmd.Parameters.Add("@RFC_BANCO", SqlDbType.VarChar).Value = TRFC.Text
                cmd.Parameters.Add("@NOMBRE_BANCO", SqlDbType.VarChar).Value = TNOMBRE.Text
                cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCalle.Text
                cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TTelefono.Text
                cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = TCiudad.Text
                cmd.Parameters.Add("@CORREO1", SqlDbType.VarChar).Value = TCorreo.Text
                cmd.Parameters.Add("@SALDO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TSALDO.Text)
                cmd.Parameters.Add("@CLABE", SqlDbType.VarChar).Value = TCLABE.Text
                cmd.Parameters.Add("@FECHA_APER", SqlDbType.DateTime).Value = F1.Value
                cmd.Parameters.Add("@EJECUTIVO", SqlDbType.VarChar).Value = TEJECUTIVO.Text
                cmd.Parameters.Add("@ALIAS", SqlDbType.VarChar).Value = TALIAS.Text
                cmd.Parameters.Add("@SUCURSAL", SqlDbType.VarChar).Value = TSUCURSAL.Text
                cmd.Parameters.Add("@NUM_MONED", SqlDbType.SmallInt).Value = Convert.ToInt16(CboMoneda.Items(CboMoneda.SelectedIndex).ToString.Substring(0, 2))
                cmd.Parameters.Add("@CUENTA_CONTABLE_FINANCIERA", SqlDbType.VarChar).Value = CCFINANCIERA.Text
                cmd.Parameters.Add("@CUENTA_CONTABLE_FISCAL", SqlDbType.VarChar).Value = CCFISCAL.Text
                cmd.Parameters.Add("@CUENTA_CONTABLE_FISCAL_EG", SqlDbType.VarChar).Value = CCFISCAL_EGRESOS.Text
                cmd.Parameters.Add("@CVE_BANCO", SqlDbType.Int).Value = CVE_BANCO
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
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmCtaBanEmpresaAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
End Class

